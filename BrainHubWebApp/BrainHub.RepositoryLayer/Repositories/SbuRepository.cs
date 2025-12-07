using BrainHub.DomainLayer.Data;
using BrainHub.DomainLayer.Models;
using BrainHub.RepositoryLayer.IRepositories;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace BrainHub.RepositoryLayer.Repositories
{
    public class SbuRepository : Repository<Sbu>, ISbuRepository
    {
        private readonly ApplicationDbContext _db;

        public SbuRepository(ApplicationDbContext db) : base (db)
        {
            _db = db;
        }

        //public new IEnumerable<Sbu> GetAll(Expression<Func<Sbu, bool>>? filter = null, string? includeProperties = null)
        //{
        //    var query = _db.Sbus.FromSqlRaw("EXEC usp_GetAllSbus").AsEnumerable();

        //    //if (!string.IsNullOrWhiteSpace(includeProperties))
        //    //    foreach (var includeProperty in includeProperties.Split(',', StringSplitOptions.RemoveEmptyEntries))
        //    //        query = query.Include(includeProperty.Trim());

        //    if (filter != null)
        //        query = query.Where(filter.Compile());

        //    return query.ToList();
        //}

        //public new Sbu? GetById(object id)
        //{
        //    if (id is int intId)
        //    {
        //        return _db.Sbus.FromSqlRaw("EXEC usp_GetSbuById @Id = {0}", intId).AsEnumerable().FirstOrDefault();
        //    }
        //    return null;
        //}

        //public new Sbu? Get(Expression<Func<Sbu, bool>>? filter, string? includeProperties = null)
        //{
        //    if (filter == null)
        //        return null;

        //    var query = _db.Sbus.FromSqlRaw("EXEC usp_GetAllSbus").AsEnumerable();

        //    return query.FirstOrDefault(filter.Compile());
        //}

        //public new void Add(Sbu entity)
        //{
        //    if (string.IsNullOrEmpty(entity.ImageUrl))
        //    {
        //        _db.Database.ExecuteSqlRaw("EXEC usp_AddSbu @Name = {0}, @ImageUrl = NULL",
        //            entity.Name);
        //    }
        //    else
        //    {
        //        _db.Database.ExecuteSqlRaw("EXEC usp_AddSbu @Name = {0}, @ImageUrl = {1}",
        //            entity.Name,
        //            entity.ImageUrl);
        //    }
        //}

        //public new void Update(Sbu entity)
        //{
        //    if (string.IsNullOrEmpty(entity.ImageUrl))
        //    {
        //        _db.Database.ExecuteSqlRaw("EXEC usp_UpdateSbu @Id = {0}, @Name = {1}, @ImageUrl = NULL",
        //            entity.Id,
        //            entity.Name);
        //    }
        //    else
        //    {
        //        _db.Database.ExecuteSqlRaw("EXEC usp_UpdateSbu @Id = {0}, @Name = {1}, @ImageUrl = {2}",
        //            entity.Id,
        //            entity.Name,
        //            entity.ImageUrl);
        //    }
        //}

        //public new void Delete(object id)
        //{
        //    if (id is int intId)
        //    {
        //        _db.Database.ExecuteSqlRaw("EXEC usp_DeleteSbu @Id = {0}", intId);
        //    }
        //}
    }
}