using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Biodiversity.Domain.Core;

namespace Biodiversity.BusinessServices.Interfaces
{
    public interface ILiteratureAuthorService
    {
        void AddAsync(LiteratureAuthor entity);
        Task<IEnumerable<LiteratureAuthor>> FindAllAsync(Expression<Func<LiteratureAuthor, bool>> predicate = null);
        Task<LiteratureAuthor> FindAsync(Expression<Func<LiteratureAuthor, bool>> predicate = null);
        void Add(LiteratureAuthor entity);
        LiteratureAuthor GetById(int Id);
        void Update(LiteratureAuthor entity);
        void Delete(LiteratureAuthor entity);
        long Count();
        //
        void AddRange(IEnumerable<LiteratureAuthor> entities);
        void RemoveRange(IEnumerable<LiteratureAuthor> entities);
        void SaveChanges();

        //asyncs
        Task AddEntity(LiteratureAuthor entity);
        Task UpdateEntity(LiteratureAuthor entity);
        Task DeleteEntity(LiteratureAuthor entity);
        Task CountEntity();
        Task<LiteratureAuthor> GetEntityById(int Id);
        Task<LiteratureAuthor> GetEntity(Expression<Func<LiteratureAuthor, bool>> predicate);
        Task<IEnumerable<LiteratureAuthor>> GetAllEntities();
        Task<IEnumerable<LiteratureAuthor>> GetAllEntitiesFiltered(Expression<Func<LiteratureAuthor, bool>> predicate = null);
    }
}