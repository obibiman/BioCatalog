using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Biodiversity.Domain.Core;

namespace Biodiversity.BusinessServices.Interfaces
{
    public interface ILiteratureService
    {
        void AddAsync(Literature entity);
        Task<IEnumerable<Literature>> FindAllAsync(Expression<Func<Literature, bool>> predicate = null);
        Task<Literature> FindAsync(Expression<Func<Literature, bool>> predicate = null);
        void Add(Literature entity);
        Literature GetById(int Id);
        void Update(Literature entity);
        void Delete(Literature entity);
        long Count();
        //
        void AddRange(IEnumerable<Literature> entities);
        void RemoveRange(IEnumerable<Literature> entities);
        void SaveChanges();

        //asyncs
        Task AddEntity(Literature entity);
        Task UpdateEntity(Literature entity);
        Task DeleteEntity(Literature entity);
        Task CountEntity();
        Task<Literature> GetEntityById(int Id);
        Task<Literature> GetEntity(Expression<Func<Literature, bool>> predicate);
        Task<IEnumerable<Literature>> GetAllEntities();
        Task<IEnumerable<Literature>> GetAllEntitiesFiltered(Expression<Func<Literature, bool>> predicate = null);
    }
}