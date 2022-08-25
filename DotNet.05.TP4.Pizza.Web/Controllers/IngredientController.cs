using DotNet._05.TP4.Pizza.business;
using DotNet._05.TP4.Pizza.Web.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DotNet._05.TP4.Pizza.Web.Controllers
{
    public class IngredientController : Controller
    {
        private readonly PizzeriaService pizzeriaService;

        public IngredientController(PizzeriaService pizzeriaService)
        {
            this.pizzeriaService = pizzeriaService;
        }
        // GET: IngredientController
        public ActionResult Index()
        {
            var listeIngredientViewModel = this.pizzeriaService.GetListeIngredients()
               .Select(ingredient => IngredientViewModel.FromIngredient(ingredient))
               .ToList();
            return View(listeIngredientViewModel);
        }

        // GET: IngredientController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: IngredientController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: IngredientController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
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

        // GET: IngredientController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: IngredientController/Edit/5
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

        // GET: IngredientController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: IngredientController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
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
    }
}
