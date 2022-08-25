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
            return View(PizzaViewModel.FromPizza(pizzeriaService.GetPizzaById(id)));
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
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
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

            return View(PizzaViewModel.FromPizza(this.pizzeriaService.GetListePizzas()
                .Where(p => p.Id == id)
                .FirstOrDefault()
                ));
        }

        // POST: PizzaController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
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
