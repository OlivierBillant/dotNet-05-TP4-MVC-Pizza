using DotNet._05.TP4.Pizza.business;
using DotNet._05.TP4.Pizza.Web.Models;
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
            var listePatesViewModel = this.pizzeriaService.GetListePates()
            // Transformer listePates en listePatesViewModel
            // On appelle la méthode statique de transformation de pate en pateViewModel
                .Select(pate => PateViewModel.FromPate(pate))
                .ToList();
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
        public ActionResult Create(PateViewModel pateViewModel)
        {
            try
            {
                pizzeriaService.CreatePate(PateViewModel.ToPate(pateViewModel));
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
            var pate = PateViewModel.FromPate(pizzeriaService.GetListePates().FirstOrDefault(p => p.Id == id));
            return View(pate);
        }

        // POST: PateController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(PateViewModel pateViewModel)
        {
            try
            {
                pizzeriaService.EditPate(PateViewModel.ToPate(pateViewModel));
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
