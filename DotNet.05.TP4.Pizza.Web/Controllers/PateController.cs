using DotNet._05.TP4.Pizza.business;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.DotNet.Scaffolding.Shared.ProjectModel;

namespace DotNet._05.TP4.Pizza.Web.Controllers
{
    public class PateController : Controller
    {
        private readonly PizzeriaService pizzeriaService;

        public PateController(PizzeriaService pizzeriaService)
        {
            this.pizzeriaService = pizzeriaService;
        }

        // GET: PateController
        public ActionResult Index()
        {
            var listePatesViewModel = this.pizzeriaService.getListePates()
                .Select(x => new Models.PateViewModel()
                {
                    Id = x.Id,
                    Nom = x.Nom
                })
                .ToList();
            // Transformer listePates en listePatesViewModel
            return View(listePatesViewModel);
        }

        // GET: PateController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: PateController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PateController/Create
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

        // GET: PateController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: PateController/Edit/5
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

        // GET: PateController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: PateController/Delete/5
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
