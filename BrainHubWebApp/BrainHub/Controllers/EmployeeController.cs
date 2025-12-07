using BrainHub.DomainLayer.ViewModels;
using BrainHub.ServiceLayer.IServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BrainHub.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IEmployeeService _employeeService;

        public EmployeeController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        //[Authorize(Roles = "Employee")]
        //[Authorize(Roles = "Employee,Admin", Policy = "SbuAdd")]
        [Authorize(Policy = "EmployeeIndex")]
        public IActionResult Index()
        {
            var employees = _employeeService.GetAllEmployeeVMs();
            return View(employees);
        }


        [Authorize(Policy = "EmployeeProfile")] // all user can access their profile
        public IActionResult Profile(int userId) // id here is IdentityUser.Id
        {
            var employeeVM = _employeeService.GetByUserId(userId); // find employee by UserId
            if (employeeVM == null)
                return NotFound();

            return View(employeeVM);
        }


        [Authorize(Policy = "EmployeeAdd")]
        public IActionResult Create()
        {
            return View(_employeeService.GetEmployeeVM());
        }

        [HttpPost]
        public IActionResult Create(EmployeeVM employeeVM)
        {
            if (ModelState.IsValid)
            {
                var (success, error) = _employeeService.Create(employeeVM);

                if (success)
                    return RedirectToAction(nameof(Index));

                ModelState.AddModelError(string.Empty, error);
            }

            employeeVM.SbuList = _employeeService.GetSbuList();
            return View(employeeVM);
        }

        [Authorize(Policy = "EmployeeProfileUpdate")]
        [Authorize(Policy = "EmployeeUpdate")]
        public IActionResult Update(int id, bool IsUpdatedByEmployee)
        {
            var model = _employeeService.GetEmployeeVM(id);
            if (model == null)
                return NotFound();

            model.IsUpdatedByEmployee = IsUpdatedByEmployee;
            return View(model);
        }

        [HttpPost]
        public IActionResult Update(EmployeeVM employeeVM)
        {
            // If password is empty, remove it from model state to avoid validation error           
            if (string.IsNullOrEmpty(employeeVM.Password))
                ModelState.Remove(nameof(employeeVM.Password));

            if (ModelState.IsValid)
            {
                var (success, error) = _employeeService.Update(employeeVM);

                if (success)
                {
                    if (employeeVM.IsUpdatedByEmployee)
                    {
                        // redirect to userId, because for the user profile update, i am using userId to find the Employee
                        return RedirectToAction("Profile", "Employee", new { userId = employeeVM.Employee.UserId });
                    }
                    else
                    {
                        return RedirectToAction("Index", "Employee");
                    }
                }

                ModelState.AddModelError(string.Empty, error);
            }

            return View(employeeVM);
        }


        [Authorize(Policy = "EmployeeDelete")]
        public IActionResult Delete(int id)
        {
            return View(_employeeService.GetEmployeeVM(id));
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            _employeeService.Delete(id);
            return RedirectToAction(nameof(Index));
        }
    }
}