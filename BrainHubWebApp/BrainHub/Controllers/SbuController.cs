using BrainHub.DomainLayer.Models;
using BrainHub.ServiceLayer.IServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BrainHub.Controllers
{
    public class SbuController : Controller
    {
        private readonly ISbuService _sbuService;
        public SbuController(ISbuService sbuService)
        {
            _sbuService = sbuService;
        }

        [Authorize(Policy = "SbuIndex")]
        public IActionResult Index()
        {
            var sbus = _sbuService.GetAll();
            return View(sbus);
        }

        [Authorize(Policy = "SbuAdd")]
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Sbu obj)
        {
            if (!ModelState.IsValid)
                return View(obj);
            var (success, error) = _sbuService.AddSbu(obj);
            if (!success)
            {
                ModelState.AddModelError(nameof(obj.Name), error);
                return View(obj);
            }
            return RedirectToAction("Index");
        }

        [Authorize(Policy = "SbuUpdate")]
        [HttpGet]
        public IActionResult Update(int id)
        {
            var obj = _sbuService.GetById(id);
            return View(obj);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Update(Sbu obj)
        {
            if (!ModelState.IsValid)
                return View(obj);

            var (success, error) = _sbuService.UpdateSbu(obj);
            if (!success)
            {
                ModelState.AddModelError(nameof(obj.Name), error);
                return View(obj);
            }

            return RedirectToAction("Index");
        }

        [Authorize(Policy = "SbuDelete")]
        [HttpGet]
        public IActionResult Delete(int id)
        {
            return View(_sbuService.GetById(id));
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            _sbuService.Delete(id);
            return RedirectToAction("Index");
        }
    }
}
