using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Biodiversity.Domain.Core;

namespace Biodiversity.BusinessServices.Interfaces
{
    public interface ITaxonService
    {
        void AddAsync(Taxon entity);
        Task<IEnumerable<Taxon>> FindAllAsync(Expression<Func<Taxon, bool>> predicate = null);
        Task<Taxon> FindAsync(Expression<Func<Taxon, bool>> predicate = null);
        void Add(Taxon entity);
        Taxon GetById(int Id);
        void Update(Taxon entity);
        void Delete(Taxon entity);
        long Count();
        //
        void AddRange(IEnumerable<Taxon> entities);
        void RemoveRange(IEnumerable<Taxon> entities);
        void SaveChanges();

        //asyncs
        Task AddEntity(Taxon entity);
        Task UpdateEntity(Taxon entity);
        Task DeleteEntity(Taxon entity);
        Task CountEntity();
        Task<Taxon> GetEntityById(int Id);
        Task<Taxon> GetEntity(Expression<Func<Taxon, bool>> predicate);
        Task<IEnumerable<Taxon>> GetAllEntities();
        Task<IEnumerable<Taxon>> GetAllEntitiesFiltered(Expression<Func<Taxon, bool>> predicate = null);
    }
}