using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Biodiversity.Domain.Core;

namespace Biodiversity.BusinessServices.Interfaces
{
    public interface ITaxonLiteratureService
    {
        void AddAsync(TaxonLiterature entity);
        Task<IEnumerable<TaxonLiterature>> FindAllAsync(Expression<Func<TaxonLiterature, bool>> predicate = null);
        Task<TaxonLiterature> FindAsync(Expression<Func<TaxonLiterature, bool>> predicate = null);
        void Add(TaxonLiterature entity);
        TaxonLiterature GetById(int Id);
        void Update(TaxonLiterature entity);
        void Delete(TaxonLiterature entity);
        long Count();
        //
        void AddRange(IEnumerable<TaxonLiterature> entities);
        void RemoveRange(IEnumerable<TaxonLiterature> entities);
        void SaveChanges();

        //asyncs
        Task AddEntity(TaxonLiterature entity);
        Task UpdateEntity(TaxonLiterature entity);
        Task DeleteEntity(TaxonLiterature entity);
        Task CountEntity();
        Task<TaxonLiterature> GetEntityById(int Id);
        Task<TaxonLiterature> GetEntity(Expression<Func<TaxonLiterature, bool>> predicate);
        Task<IEnumerable<TaxonLiterature>> GetAllEntities();
        Task<IEnumerable<TaxonLiterature>> GetAllEntitiesFiltered(Expression<Func<TaxonLiterature, bool>> predicate = null);
    }
}