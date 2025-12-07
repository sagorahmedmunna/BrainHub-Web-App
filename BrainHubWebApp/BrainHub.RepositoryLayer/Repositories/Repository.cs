using BrainHub.DomainLayer.Data;
using BrainHub.RepositoryLayer.IRepositories;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace BrainHub.RepositoryLayer.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly ApplicationDbContext _db;
        internal DbSet<T> dbSet;

        public Repository(ApplicationDbContext db)
        {
            _db = db;
            dbSet = _db.Set<T>();
        }

        public void Add(T entity)
        {
            dbSet.Add(entity);
            _db.SaveChanges();
        }

        public void Delete(object id)
        {
            var entity = dbSet.Find(id);
            if (entity != null)
            {
                dbSet.Remove(entity);
                _db.SaveChanges();
            }
        }

        public T? Get(Expression<Func<T, bool>>? filter, string? includeProperties = null)
        {
            IQueryable<T> query = _db.Set<T>();
            if (filter != null)
                query = query.Where(filter);

            if (includeProperties != null)
            {
                foreach (var includeProperty in includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                    query = query.Include(includeProperty);
            }

            return query.FirstOrDefault();
        }

        public IEnumerable<T> GetAll(Expression<Func<T, bool>>? filter = null, string? includeProperties = null)
        {
            IQueryable<T> query = _db.Set<T>();
            if (filter != null)
                query = query.Where(filter);

            if (includeProperties != null)
            {
                foreach (var includeProperty in includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                    query = query.Include(includeProperty);
            }

            return query.ToList();
        }

        public T? GetById(object id)
        {
            return dbSet.Find(id);
        }


        public void Update(T entity)
        {
            dbSet.Update(entity);
            _db.SaveChanges();
        }
    }
}
