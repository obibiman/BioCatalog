using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Biodiversity.Domain.Core;

namespace Biodiversity.BusinessServices.Interfaces
{
    public interface IAuthorService
    {
        Task AddAsync(Author entity);
        Task<IEnumerable<Author>> FindAllAsync(Expression<Func<Author, bool>> predicate = null);
        Task<Author> FindAsync(Expression<Func<Author, bool>> predicate = null);
        void Add(Author entity);
        Author GetById(int Id);
        void Update(Author entity);
        void Delete(Author entity);
        long Count();
        //
        void AddRange(IEnumerable<Author> entities);
        void RemoveRange(IEnumerable<Author> entities);
        void SaveChanges();

        //asyncs
        Task AddEntity(Author entity);
        Task UpdateEntity(Author entity);
        Task DeleteEntity(Author entity);
        Task CountEntity();
        Task<Author> GetEntityById(int Id);
        Task<Author> GetEntity(Expression<Func<Author, bool>> predicate);
        Task<IEnumerable<Author>> GetAllEntities();
        Task<IEnumerable<Author>> GetAllEntitiesFiltered(Expression<Func<Author, bool>> predicate = null);
    }
}