using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BrainHub.DomainLayer.Models
{
    public class Employee
    {
        [Key]
        public int Id { get; set; }
        public required string Name { get; set; } = null!;
        public string? Number { get; set; }

        
        [ForeignKey("Sbu")]
        public int SbuId { get; set; }
        [ValidateNever]
        public Sbu? Sbu { get; set; }


        [ForeignKey(nameof(User))]
        public int? UserId { get; set; }
        [ValidateNever]
        public IdentityUser<int>? User { get; set; }


        [ForeignKey(nameof(CustomRole))]
        public int? CustomRoleId { get; set; }
        public CustomRole? CustomRole { get; set; }
    }
}
