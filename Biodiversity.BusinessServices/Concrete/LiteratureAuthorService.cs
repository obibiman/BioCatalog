using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using AutoMapper;
using Biodiversity.BusinessServices.Interfaces;
using Biodiversity.DataAccess.SqlDataTier.Repository.UnitOfWork;
using Biodiversity.Domain.Core;

namespace Biodiversity.BusinessServices.Concrete
{
    public class LiteratureAuthorService : ILiteratureAuthorService
    {
        private readonly UnitOfWork _unitOfWork;
        /// <summary>
        /// Public constructor.
        /// </summary>
        public LiteratureAuthorService(UnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void AddAsync(LiteratureAuthor entity)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<LiteratureAuthor>> FindAllAsync(Expression<Func<LiteratureAuthor, bool>> predicate = null)
        {
            throw new NotImplementedException();
        }

        public Task<LiteratureAuthor> FindAsync(Expression<Func<LiteratureAuthor, bool>> predicate = null)
        {
            throw new NotImplementedException();
        }

        public void Add(LiteratureAuthor entity)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<Biodiversity.DataAccess.SqlDataTier.Entity.LiteratureAuthor, LiteratureAuthor>());
            var mapper = config.CreateMapper();
            //LiteratureAuthor dto = mapper.Map<OrderDto>(order);
            throw new NotImplementedException();
        }

        public LiteratureAuthor GetById(int Id)
        {
            throw new NotImplementedException();
        }

        public void Update(LiteratureAuthor entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(LiteratureAuthor entity)
        {
            throw new NotImplementedException();
        }

        public long Count()
        {
            throw new NotImplementedException();
        }

        public void AddRange(IEnumerable<LiteratureAuthor> entities)
        {
            throw new NotImplementedException();
        }

        public void RemoveRange(IEnumerable<LiteratureAuthor> entities)
        {
            throw new NotImplementedException();
        }

        public void SaveChanges()
        {
            throw new NotImplementedException();
        }

        public Task AddEntity(LiteratureAuthor entity)
        {
            throw new NotImplementedException();
        }

        public Task UpdateEntity(LiteratureAuthor entity)
        {
            throw new NotImplementedException();
        }

        public Task DeleteEntity(LiteratureAuthor entity)
        {
            throw new NotImplementedException();
        }

        public Task CountEntity()
        {
            throw new NotImplementedException();
        }

        public Task<LiteratureAuthor> GetEntityById(int Id)
        {
            throw new NotImplementedException();
        }

        public Task<LiteratureAuthor> GetEntity(Expression<Func<LiteratureAuthor, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<LiteratureAuthor>> GetAllEntities()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<LiteratureAuthor>> GetAllEntitiesFiltered(Expression<Func<LiteratureAuthor, bool>> predicate = null)
        {
            throw new NotImplementedException();
        }
    }
}