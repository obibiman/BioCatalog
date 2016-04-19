using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Linq.Expressions;
using Biodiversity.Web.DataAccess.Repository.Interface;

namespace Biodiversity.Web.DataAccess.Repository.Concrete
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly Biocontext _context;
        private readonly DbSet<T> _dbSet;

        public Repository(Biocontext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }

        public IEnumerable<T> GetAll(Expression<Func<T, bool>> predicate = null)
        {
            if (predicate != null)
            {
                return _dbSet.Where(predicate);
            }
            return _dbSet.AsEnumerable();
        }

        public T Get(Expression<Func<T, bool>> predicate)
        {
            return _dbSet.FirstOrDefault(predicate);
        }

        public T GetById(int Id)
        {
            return _dbSet.Find(Id);
        }

        public ICollection<T> GetAll()
        {
            return _dbSet.AsEnumerable().ToList();
        }

        public void Add(T entity)
        {
            _dbSet.Add(entity);
        }

        public void Update(T entity)
        {
            _dbSet.Attach(entity);
            ((IObjectContextAdapter) _context).ObjectContext.
                ObjectStateManager.ChangeObjectState(entity, EntityState.Modified);
        }

        public void Delete(T entity)
        {
            _dbSet.Remove(entity);
        }

        public long Count()
        {
            return _dbSet.Count();
        }
    }
}