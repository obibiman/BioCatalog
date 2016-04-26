using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Biodiversity.Domain.Core;

namespace Biodiversity.BusinessServices.Interfaces
{
    public interface ITaxonAuthorService
    {
        void AddAsync(TaxonAuthor entity);
        Task<IEnumerable<TaxonAuthor>> FindAllAsync(Expression<Func<TaxonAuthor, bool>> predicate = null);
        Task<TaxonAuthor> FindAsync(Expression<Func<TaxonAuthor, bool>> predicate = null);
        void Add(TaxonAuthor entity);
        TaxonAuthor GetById(int Id);
        void Update(TaxonAuthor entity);
        void Delete(TaxonAuthor entity);
        long Count();
        //
        void AddRange(IEnumerable<TaxonAuthor> entities);
        void RemoveRange(IEnumerable<TaxonAuthor> entities);
        void SaveChanges();

        //asyncs
        Task AddEntity(TaxonAuthor entity);
        Task UpdateEntity(TaxonAuthor entity);
        Task DeleteEntity(TaxonAuthor entity);
        Task CountEntity();
        Task<TaxonAuthor> GetEntityById(int Id);
        Task<TaxonAuthor> GetEntity(Expression<Func<TaxonAuthor, bool>> predicate);
        Task<IEnumerable<TaxonAuthor>> GetAllEntities();
        Task<IEnumerable<TaxonAuthor>> GetAllEntitiesFiltered(Expression<Func<TaxonAuthor, bool>> predicate = null);
    }
}