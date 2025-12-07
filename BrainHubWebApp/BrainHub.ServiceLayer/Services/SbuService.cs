using BrainHub.DomainLayer.Models;
using BrainHub.RepositoryLayer.IRepositories;
using BrainHub.ServiceLayer.IServices;
using Microsoft.AspNetCore.Identity;
using System.Linq.Expressions;

namespace BrainHub.ServiceLayer.Services
{
    public class SbuService : ISbuService
    {
        private readonly ISbuRepository _sbuRepository;
        private readonly IEmployeeRepository _employeeRepository;
        private readonly UserManager<IdentityUser<int>> _userManager;

        public SbuService(ISbuRepository sbuRepository, IEmployeeRepository employeeRepository, UserManager<IdentityUser<int>> userManager)
        {
            _sbuRepository = sbuRepository;
            _employeeRepository = employeeRepository;
            _userManager = userManager;
        }

        public IEnumerable<Sbu> GetAll(Expression<Func<Sbu, bool>>? filter = null)
        {
            return _sbuRepository.GetAll();
        }

        public Sbu? GetById(int id)
        {
            return _sbuRepository.GetById(id);
        }

        public Sbu? Get(Expression<Func<Sbu, bool>>? filter)
        {
            return _sbuRepository.Get(filter);
        }

        public (bool success, string error) AddSbu(Sbu entity)
        {
            if (_sbuRepository.Get(x => x.Name == entity.Name) != null)
                return (false, "This name already exists.");

            _sbuRepository.Add(entity);
            return (true, string.Empty);
        }

        public (bool success, string error) UpdateSbu(Sbu entity)
        {
            var existing = _sbuRepository.Get(x => x.Name == entity.Name && x.Id != entity.Id);
            if (existing != null)
                return (false, "This name already exists.");

            _sbuRepository.Update(entity);
            return (true, string.Empty);
        }

        public void Delete(int id)
        {
            var employees = _employeeRepository.GetAll(x => x.SbuId == id, includeProperties: "User");

            // Delete each employee and their associated user
            foreach (var employee in employees)
            {
                // Delete the Identity User first
                if (employee.UserId > 0)
                {
                    var user = _userManager.FindByIdAsync(employee.UserId.ToString()!).Result;
                    if (user != null)
                    {
                        _userManager.DeleteAsync(user).Wait();
                    }
                }
                // Delete the Employee record
                _employeeRepository.Delete(employee.Id);
            }
            // Finally, delete the SBU
            _sbuRepository.Delete(id);
        }
    }
}