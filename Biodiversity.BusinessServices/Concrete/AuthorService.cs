using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Biodiversity.DataAccess.SqlDataTier.Entity;
using Biodiversity.DataAccess.SqlDataTier.Repository.UnitOfWork;
using Biodiversity.Domain.Core;
using AutoMapper;
using Biodiversity.BusinessServices.Interfaces;
using Author = Biodiversity.Domain.Core.Author;

namespace Biodiversity.BusinessServices.Concrete
{
    public class AuthorService : IAuthorService
    {
        private readonly UnitOfWork _unitOfWork;
        /// <summary>
        /// Public constructor.
        /// </summary>
        public AuthorService(UnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public Task AddAsync(Author entity)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Author>> FindAllAsync(Expression<Func<Author, bool>> predicate = null)
        {
            throw new NotImplementedException();
        }

        public Task<Author> FindAsync(Expression<Func<Author, bool>> predicate = null)
        {
            throw new NotImplementedException();
        }

        public void Add(Author entity)
        {
            throw new NotImplementedException();
        }

        public Author GetById(int Id)
        {
            throw new NotImplementedException();
        }

        public void Update(Author entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(Author entity)
        {
            throw new NotImplementedException();
        }

        public long Count()
        {
            throw new NotImplementedException();
        }

        public void AddRange(IEnumerable<Author> entities)
        {
            throw new NotImplementedException();
        }

        public void RemoveRange(IEnumerable<Author> entities)
        {
            throw new NotImplementedException();
        }

        public void SaveChanges()
        {
            throw new NotImplementedException();
        }

        public Task AddEntity(Author entity)
        {
            throw new NotImplementedException();
        }

        public Task UpdateEntity(Author entity)
        {
            throw new NotImplementedException();
        }

        public Task DeleteEntity(Author entity)
        {
            throw new NotImplementedException();
        }

        public Task CountEntity()
        {
            throw new NotImplementedException();
        }

        public Task<Author> GetEntityById(int Id)
        {
            throw new NotImplementedException();
        }

        public Task<Author> GetEntity(Expression<Func<Author, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Author>> GetAllEntities()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Author>> GetAllEntitiesFiltered(Expression<Func<Author, bool>> predicate = null)
        {
            throw new NotImplementedException();
        }
    }
}