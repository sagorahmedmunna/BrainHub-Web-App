using BrainHub.DomainLayer.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace BrainHub.DomainLayer.ViewModels
{
    public class EmployeeVM
    {
        public Employee Employee { get; set; }
        public IEnumerable<SelectListItem> SbuList { get; set; }
        public IEnumerable<SelectListItem> CustomRoleList { get; set; }

        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Invalid email address")]
        public string Email { get; set; }

        
        [Required(ErrorMessage = "Password is required")]
        //[DataType(DataType.Password)]
        //[StringLength(100, MinimumLength = 6, ErrorMessage = "Password must be at least 6 characters long")]
        public string? Password { get; set; }
        [Display(Name = "Confirm Password")]
        [Compare("Password", ErrorMessage = "Passwords do not match.")]
        public string? ConfirmPassword { get; set; }
        
        public string Role { get; set; }
        public bool IsUpdatedByEmployee { get; set; }

        public EmployeeVM()
        {
            Employee = new Employee { Name = string.Empty };
            SbuList = new List<SelectListItem>();
            CustomRoleList = new List<SelectListItem>();
            Email = string.Empty;
            Password = string.Empty;
            IsUpdatedByEmployee = false;
            Role = string.Empty;
        }
    }
}