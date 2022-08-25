using DotNet._05.TP4.Pizza.business;
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
        // GET: PiizaController
        public ActionResult Index()
        {
            this.ViewData["listePates"] = pizzeriaService.GetListePates()
                .Select(PateViewModel.FromPate)
                .ToList();
            var listePizzaViewModel = this.pizzeriaService.GetListePizzas()
                .Select(pizza => PizzaViewModel.FromPizza(pizza))
                .ToList();
            return View(listePizzaViewModel);
        }

        // GET: PiizaController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: PiizaController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PiizaController/Create
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

        // GET: PiizaController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: PiizaController/Edit/5
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

        // GET: PiizaController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: PiizaController/Delete/5
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
