using DotNet._05.TP4.Pizza.business;
using DotNet._05.TP4.Pizza.business.Models;
using DotNet._05.TP4.Pizza.Web.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DotNet._05.TP4.Pizza.Web.Controllers
{
    public class PizzaController : Controller
    {
        private readonly PizzeriaService pizzeriaService;

        public PizzaController(PizzeriaService pizzeriaService)
        {
            this.pizzeriaService = pizzeriaService;
        }
        // GET: PizzaController
        public ActionResult Index()
        {
            var listePizzaViewModel = this.pizzeriaService.GetListePizzas()
                .Select(pizza => PizzaViewModel.FromPizza(pizza))
                .ToList();
            return View(listePizzaViewModel);
        }

        // GET: PizzaController/Details/5
        public ActionResult Details(int id)
        {
            this.ViewData["listePates"] = pizzeriaService.GetListePates()
            .Select(PateViewModel.FromPate)
            .ToList();
            this.ViewData["listeIngredients"] = pizzeriaService.GetListeIngredients()
                    .Select(IngredientViewModel.FromIngredient)
                    .ToList();
            return View(PizzaFormViewModel.FromPizza(pizzeriaService.GetPizzaById(id)));
        }

        // GET: PizzaController/Create
        public ActionResult Create()
        {
            this.ViewData["listePates"] = pizzeriaService.GetListePates()
            .Select(PateViewModel.FromPate)
            .ToList();
            this.ViewData["listeIngredients"] = pizzeriaService.GetListeIngredients()
                    .Select(IngredientViewModel.FromIngredient)
                    .ToList();
            return View();
        }

        // POST: PizzaController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(PizzaFormViewModel pizzaFormViewModel)
        {
            try
            {
                if (this.ModelState.IsValid)
                {
                    //Validation sur l'existance d'une pizza portant ce nom
                    if (pizzeriaService.GetListePizzas()
                        .Any(p => p.Nom.ToUpper() == pizzaFormViewModel.Nom.ToUpper()))
                    {
                        this.ModelState.AddModelError("", "Il existe déjà une pizza portant ce nom !");
                        return this.View();
                    }

                    //Validation sur le nombre d'ingrédients
                    if (pizzaFormViewModel.IngredientsId.Count < 2 || pizzaFormViewModel.IngredientsId.Count > 5)
                    {
                        this.ModelState.AddModelError("", "La pizza doit comporter entre 2 et 5 ingrédients");
                        //Idealement transformer les lignes suivantes en populateLists
                        this.ViewData["listePates"] = pizzeriaService.GetListePates()
                            .Select(PateViewModel.FromPate)
                            .ToList();
                        this.ViewData["listeIngredients"] = pizzeriaService.GetListeIngredients()
                            .Select(IngredientViewModel.FromIngredient)
                            .ToList();
                        return this.View();
                    }

                    //Validation sur des pizza ayant les mêmes ingrédients
                    if (DoublonPizza(pizzaFormViewModel))
                    {
                        this.ModelState.AddModelError("", "Une pizza ayant la même composition existe déjà");
                        this.ViewData["listePates"] = pizzeriaService.GetListePates()
                            .Select(PateViewModel.FromPate)
                            .ToList();
                        this.ViewData["listeIngredients"] = pizzeriaService.GetListeIngredients()
                            .Select(IngredientViewModel.FromIngredient)
                            .ToList();
                        return this.View();
                    }



                    PateViewModel pateViewModel = PateViewModel.FromPate(pizzeriaService.GetListePates()
                        .Where(pate => pate.Id == pizzaFormViewModel.PateId)
                        .FirstOrDefault());


                    List<IngredientViewModel> listeIngredientsViewModel = new List<IngredientViewModel>();
                    foreach (var id in pizzaFormViewModel.IngredientsId)
                    {
                        IngredientViewModel ingredientViewModel = IngredientViewModel.FromIngredient(pizzeriaService.GetListeIngredients()
                             .Where(ingredient => ingredient.Id == id)
                             .FirstOrDefault());
                        listeIngredientsViewModel.Add(ingredientViewModel);
                    }

                    var pizzaViewModel = new PizzaViewModel(
                        pizzaFormViewModel.Id,
                        pizzaFormViewModel.Nom,
                        pateViewModel,
                        listeIngredientsViewModel
                        );

                    pizzeriaService.CreatePizza(PizzaViewModel.ToPizza(pizzaViewModel));
                }
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        private bool DoublonPizza(PizzaFormViewModel pizzaFormViewModel)
        {
            var compteur = 0;
            foreach (var pizza in pizzeriaService.GetListePizzas())
            {
                if (pizzaFormViewModel.IngredientsId
                    .OrderBy(i => i)
                    .SequenceEqual(pizza.Ingredients.Select(i => i.Id).OrderBy(id => id))
                    )
                {
                    compteur++;
                }
            };
            var result = (compteur > 0) ? true : false;
            return result;

            /*
             Alternative jsute en linQ
           return pizzas.Any(pizza =>
                    pizza.Ingredients.Select(i => i.Id).OrderBy(id => id)
                    .SequenceEqual(pizzaFormViewModel.IngredientsId.OrderBy(i => i))
                   );
             */
        }

        // GET: PizzaController/Edit/5
        public ActionResult Edit(int id)
        {
            this.ViewData["listePates"] = pizzeriaService.GetListePates()
           .Select(PateViewModel.FromPate)
           .ToList();
            this.ViewData["listeIngredients"] = pizzeriaService.GetListeIngredients()
                    .Select(IngredientViewModel.FromIngredient)
                    .ToList();

            return View(PizzaFormViewModel.FromPizza(this.pizzeriaService.GetListePizzas()
                .Where(p => p.Id == id)
                .FirstOrDefault()
                ));
        }

        // POST: PizzaController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(PizzaFormViewModel pizzaFormViewModel)
        {
            try
            {
                PateViewModel pateViewModel = PateViewModel.FromPate(pizzeriaService.GetListePates()
                         .Where(pate => pate.Id == pizzaFormViewModel.PateId)
                         .FirstOrDefault());


                List<IngredientViewModel> listeIngredientsViewModel = new List<IngredientViewModel>();
                foreach (var id in pizzaFormViewModel.IngredientsId)
                {
                    IngredientViewModel ingredientViewModel = IngredientViewModel.FromIngredient(pizzeriaService.GetListeIngredients()
                         .Where(ingredient => ingredient.Id == id)
                         .FirstOrDefault());
                    listeIngredientsViewModel.Add(ingredientViewModel);
                }

                var pizzaViewModelToEdit = pizzeriaService.GetListePizzas().FirstOrDefault(p => p.Id == pizzaFormViewModel.Id);
                pizzaViewModelToEdit.Id = pizzaFormViewModel.Id;
                pizzaViewModelToEdit.Nom = pizzaFormViewModel.Nom;
                pizzaViewModelToEdit.Pate = PateViewModel.ToPate(pateViewModel);
                pizzaViewModelToEdit.Ingredients = listeIngredientsViewModel
                    .Select(IngredientViewModel.ToIngredient)
                    .ToList();

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: PizzaController/Delete/5
        public ActionResult Delete(int id)
        {
            return View(PizzaViewModel.FromPizza(pizzeriaService.GetPizzaById(id)));
        }

        // POST: PizzaController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                pizzeriaService.RemovePizza(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
