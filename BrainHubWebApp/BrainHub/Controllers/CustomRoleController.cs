using BrainHub.DomainLayer.Models;
using BrainHub.ServiceLayer.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BrainHub.Controllers
{
    public class CustomRoleController : Controller
    {
        private readonly ICustomRoleService _roleService;

        public CustomRoleController(ICustomRoleService roleService)
        {
            _roleService = roleService;
        }

        // Index
        [Authorize(Policy = "CustomRoleIndex")]
        public IActionResult Index()
        {
            var roles = _roleService.GetAllRoles();
            return View(roles);
        }

        // Details
        [Authorize(Policy = "CustomRoleIndex")]
        public IActionResult Details(int id)
        {
            var role = _roleService.GetRoleById(id);
            if (role == null) return NotFound();

            return View(role);
        }

        // Create
        [Authorize(Policy = "CustomRoleAdd")]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(CustomRole role, List<string> Permissions)
        {
            if (!ModelState.IsValid)
                return View(role);

            _roleService.CreateRole(role, Permissions);
            return RedirectToAction("Index");
        }

        // Update
        [Authorize(Policy = "CustomRoleUpdate")]
        public IActionResult Update(int id)
        {
            var role = _roleService.GetRoleById(id);
            if (role == null) return NotFound();

            return View(role);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Update(int id, CustomRole role, List<string> Permissions)
        {
            if (!ModelState.IsValid)
                return View(role);

            _roleService.UpdateRole(id, role, Permissions);
            return RedirectToAction("Index");
        }

        // Delete
        [Authorize(Policy = "CustomRoleDelete")]
        public IActionResult Delete(int id)
        {
            var role = _roleService.GetRoleById(id);
            if (role == null) return NotFound();

            return View(role);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            _roleService.DeleteRole(id);
            return RedirectToAction("Index");
        }
    }
}
