using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Biodiversity.DataAccess.SqlDataTier.Repository.Interface
{
    public interface IRepository<T> where T : class
    {
        IEnumerable<T> GetAll(Expression<Func<T, bool>> predicate = null);
        T Get(Expression<Func<T, bool>> predicate);
        T GetById(int Id);
        ICollection<T> GetAll();
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
        long Count();
    }
}