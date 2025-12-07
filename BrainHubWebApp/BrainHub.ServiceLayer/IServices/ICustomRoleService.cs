using BrainHub.DomainLayer.Models;

namespace BrainHub.ServiceLayer.Services
{
    public interface ICustomRoleService
    {
        List<CustomRole> GetAllRoles();
        CustomRole? GetRoleById(int id);
        void CreateRole(CustomRole role, List<string>? permissions);
        void UpdateRole(int id, CustomRole role, List<string>? permissions);
        void DeleteRole(int id);
    }
}
