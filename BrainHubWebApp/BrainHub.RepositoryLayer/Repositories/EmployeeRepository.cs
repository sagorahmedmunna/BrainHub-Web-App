using BrainHub.DomainLayer.Data;
using BrainHub.DomainLayer.Models;
using BrainHub.RepositoryLayer.IRepositories;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace BrainHub.RepositoryLayer.Repositories
{
    public class EmployeeRepository : Repository<Employee>, IEmployeeRepository
    {
        private readonly ApplicationDbContext _db;
        public EmployeeRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        //public new IEnumerable<Employee> GetAll(Expression<Func<Employee, bool>>? filter = null, string? includeProperties = null)
        //{
        //    var query = _db.Employees.FromSqlRaw("EXEC usp_GetAllEmployees").AsEnumerable();
            
        //    if (filter != null)
        //        query = query.Where(filter.Compile());

        //    return query.ToList();
        //}
        //public new Employee? GetById(object id)
        //{
        //    if (id is int intId)
        //    {
        //        return _db.Employees.FromSqlRaw("EXEC usp_GetEmployeeById @Id = {0}", intId).AsEnumerable().FirstOrDefault();
        //    }
        //    return null;
        //}
        //public new Employee? Get(Expression<Func<Employee, bool>>? filter, string? includeProperties = null)
        //{
        //    if (filter == null)
        //        return null;

        //    var query = _db.Employees.FromSqlRaw("EXEC usp_GetAllEmployees").AsEnumerable();

        //    return query.FirstOrDefault(filter.Compile());
        //}

        //public new void Add(Employee entity)
        //{
        //    _db.Database.ExecuteSqlRaw(
        //        "EXEC usp_CreateEmployee @Name = {0}, @Number = {1}, @SbuId = {2}, @UserId = {3}, @CustomRoleId = {4}",
        //        entity.Name,
        //        entity.Number,
        //        entity.SbuId,
        //        entity.UserId,
        //        entity.CustomRoleId);
        //}

        //public new void Update(Employee entity)
        //{
        //    _db.Database.ExecuteSqlRaw(
        //        "EXEC usp_UpdateEmployee @Id = {0}, @Name = {1}, @Number = {2}, @SbuId = {3}, @CustomRoleId = {4}",
        //        entity.Id,
        //        entity.Name,
        //        entity.Number,
        //        entity.SbuId,
        //        entity.CustomRoleId);
        //}

        //public new void Delete(object id)
        //{
        //    if (id is int intId)
        //    {
        //        _db.Database.ExecuteSqlRaw("EXEC usp_DeleteEmployee @Id = {0}", intId);
        //    }
        //}
    }
}
