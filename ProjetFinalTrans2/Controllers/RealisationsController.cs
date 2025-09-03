using Microsoft.AspNetCore.Mvc;
using ProjetFinalTrans2.Data.Services;
using ProjetFinalTrans2.Models;

namespace ProjetFinalTrans2.Controllers
{
    public class RealisationsController : Controller
    {
        private readonly IRealisationService _service;

        public RealisationsController(IRealisationService service)
        {
            _service = service;
        }

        public IActionResult Index()
        {
            var realisations = _service.GetAll();
            return View(realisations);
        }

        public IActionResult Details(int id)
        {
            var realisation = _service.GetById(id);
            if (realisation == null)
            {
                return NotFound();
            }
            return View(realisation);
        }

        // GET: Realisations/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Realisations/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Realisation realisation)
        {
            if (ModelState.IsValid)
            {
                _service.Add(realisation); // 👈 à créer dans le service
                return RedirectToAction(nameof(Index));
            }
            return View(realisation);
        }

        // GET: Realisations/Edit/5
        public IActionResult Edit(int id)
        {
            var realisation = _service.GetById(id);
            if (realisation == null)
            {
                return NotFound();
            }
            return View(realisation);
        }

        // POST: Realisations/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Realisation realisation)
        {
            if (id != realisation.Id)
                return NotFound();

            if (ModelState.IsValid)
            {
                _service.Update(realisation);
                return RedirectToAction(nameof(Index));
            }
            return View(realisation);
        }

        // GET: Realisations/Delete/5
        public IActionResult Delete(int id)
        {
            var realisation = _service.GetById(id);
            if (realisation == null)
            {
                return NotFound();
            }
            return View(realisation);
        }

        // POST: Realisations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            _service.Delete(id);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Produits()
        {
            var realisations = _service.GetAll();
            return View(realisations);
        }




    }
}
