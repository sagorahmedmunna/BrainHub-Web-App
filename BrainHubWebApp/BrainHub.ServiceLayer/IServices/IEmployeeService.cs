using BrainHub.DomainLayer.Models;
using BrainHub.DomainLayer.ViewModels;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BrainHub.ServiceLayer.IServices
{
    public interface IEmployeeService
    {
        IEnumerable<Employee> GetAll();
        IEnumerable<EmployeeVM> GetAllEmployeeVMs();
        Employee? GetById(int id);
        EmployeeVM GetByUserId(int id);
        (bool success, string error) Create(EmployeeVM employeeVM);
        (bool success, string error) Update(EmployeeVM employeeVM);
        void Delete(int id);
        IEnumerable<SelectListItem> GetSbuList();
        EmployeeVM GetEmployeeVM(int? id = null);
    }
}