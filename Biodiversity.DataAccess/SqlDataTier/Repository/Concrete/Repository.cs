using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Linq.Expressions;
using Biodiversity.DataAccess.SqlDataTier.Repository.Interface;

namespace Biodiversity.DataAccess.SqlDataTier.Repository.Concrete
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly DbContext _context;
        //private readonly DbSet<T> _dbSet;

        public Repository(DbContext context)
        {
            _context = context;
        }

        public IEnumerable<T> GetAll(Expression<Func<T, bool>> predicate = null)
        {
            var retVal = new List<T>() as IEnumerable<T>;
            if (predicate != null)
            {
                retVal = _context.Set<T>().Where(predicate);
            }
            return retVal;
        }

        public T Get(Expression<Func<T, bool>> predicate)
        {
            return _context.Set<T>().FirstOrDefault(predicate);
        }

        public T GetById(int Id)
        {
            return _context.Set<T>().Find(Id);
        }

        public ICollection<T> GetAll()
        {
            return _context.Set<T>().AsEnumerable().ToList();
        }

        public void Add(T entity)
        {
            _context.Set<T>().Add(entity);
        }

        public void Update(T entity)
        {
            _context.Set<T>().Attach(entity);
            ((IObjectContextAdapter) _context).ObjectContext.
                ObjectStateManager.ChangeObjectState(entity, EntityState.Modified);
        }

        public void Delete(T entity)
        {
            _context.Set<T>().Remove(entity);
        }

        public long Count()
        {
            return _context.Set<T>().Count();
        }

        public void AddRange(IEnumerable<T> entities)
        {
            _context.Set<T>().AddRange(entities);
        }

        public void RemoveRange(IEnumerable<T> entities)
        {
            _context.Set<T>().RemoveRange(entities);
        }
    }
}