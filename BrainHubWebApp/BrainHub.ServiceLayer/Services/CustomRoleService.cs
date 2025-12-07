using BrainHub.DomainLayer.Models;
using BrainHub.RepositoryLayer.IRepositories;

namespace BrainHub.ServiceLayer.Services
{
    public class CustomRoleService : ICustomRoleService
    {
        private readonly ICustomRoleRepository _customRoleRepository;

        public CustomRoleService(ICustomRoleRepository customRoleRepository)
        {
            _customRoleRepository = customRoleRepository;
        }

        public List<CustomRole> GetAllRoles()
        {
            return _customRoleRepository.GetAll().ToList();
        }

        public CustomRole? GetRoleById(int id)
        {
            return _customRoleRepository.GetById(id);
        }

        public void CreateRole(CustomRole role, List<string>? permissions)
        {
            if (permissions != null && permissions.Any())
                role.Permissions = string.Join(",", permissions);
            else
                role.Permissions = null;

            _customRoleRepository.Add(role);
        }

        public void UpdateRole(int id, CustomRole role, List<string>? permissions)
        {
            role.Id = id;
            role.Permissions = permissions != null && permissions.Any()
                                                 ? string.Join(",", permissions)
                                                 : null;
            _customRoleRepository.Update(role);
        }

        public void DeleteRole(int id)
        {
            _customRoleRepository.Delete(id);
        }
    }
}
