using BrainHub.DomainLayer.Data;
using BrainHub.DomainLayer.Models;
using BrainHub.RepositoryLayer.IRepositories;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace BrainHub.RepositoryLayer.Repositories
{
    public class CustomRoleRepository : Repository<CustomRole>, ICustomRoleRepository
    {
        private readonly ApplicationDbContext _db;
        public CustomRoleRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }
        //public new IEnumerable<CustomRole> GetAll(Expression<Func<CustomRole, bool>>? filter = null, string? includeProperties = null)
        //{
        //    var query = _db.CustomRoles.FromSqlRaw("EXEC usp_GetAllCustomRoles").AsEnumerable();

        //    if (filter != null)
        //        query = query.Where(filter.Compile());

        //    return query.ToList();
        //}

        //public new CustomRole? GetById(object id)
        //{
        //    if (id is int intId)
        //    {
        //        return _db.CustomRoles.FromSqlRaw("EXEC usp_GetCustomRoleById @Id = {0}", intId).AsEnumerable().FirstOrDefault();
        //    }
        //    return null;
        //}

        //public new CustomRole? Get(Expression<Func<CustomRole, bool>>? filter, string? includeProperties = null)
        //{
        //    if (filter == null)
        //        return null;

        //    var query = _db.CustomRoles.FromSqlRaw("EXEC usp_GetAllCustomRoles").AsEnumerable();

        //    return query.FirstOrDefault(filter.Compile());
        //}

        //public new void Add(CustomRole entity)
        //{
        //    _db.Database.ExecuteSqlRaw(
        //        "EXEC usp_CreateCustomRole @Name = {0}, @Permissions = {1}",
        //        entity.Name,
        //        entity.Permissions ?? (object)DBNull.Value);
        //}

        //public new void Update(CustomRole entity)
        //{
        //    _db.Database.ExecuteSqlRaw(
        //        "EXEC usp_UpdateCustomRole @Id = {0}, @Name = {1}, @Permissions = {2}",
        //        entity.Id,
        //        entity.Name,
        //        entity.Permissions ?? (object)DBNull.Value);
        //}

        //public new void Delete(object id)
        //{
        //    if (id is int intId)
        //    {
        //        _db.Database.ExecuteSqlRaw("EXEC usp_DeleteCustomRole @Id = {0}", intId);
        //    }
        //}
    }
}
