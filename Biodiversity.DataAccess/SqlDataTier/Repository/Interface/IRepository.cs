using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Biodiversity.DataAccess.SqlDataTier.Repository.Interface
{
    public interface IRepository<T> where T : class
    {
        T Get(Expression<Func<T, bool>> predicate);
        T GetById(int Id);
        IEnumerable<T> GetAll();
        IEnumerable<T> GetAll(Expression<Func<T, bool>> predicate = null);

        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
        long Count();
        //
        void AddRange(IEnumerable<T> entities);
        void RemoveRange(IEnumerable<T> entities);
        //asyncs
        //Task AddEntity(T entity);
        //Task UpdateEntity(T entity);
        //Task DeleteEntity(T entity);
        //Task CountEntity();
        //Task<T> GetEntityById(int Id);
        //Task<T> GetEntity(Expression<Func<T, bool>> predicate);
        //Task<IEnumerable<T>> GetAllEntities();
        //Task<IEnumerable<T>> GetAllEntitiesFiltered(Expression<Func<T, bool>> predicate = null);
    }
}