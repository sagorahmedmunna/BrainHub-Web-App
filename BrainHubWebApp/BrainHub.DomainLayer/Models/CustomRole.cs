namespace BrainHub.DomainLayer.Models
{
    public class CustomRole
    {
        public int Id { get; set; }
        public required string Name { get; set; }

        // Comma-separated list of permissions like "SbuAdd,SbuUpdate,EmployeeAdd,EmployeeUpdate"
        public string? Permissions { get; set; }
    }
}
