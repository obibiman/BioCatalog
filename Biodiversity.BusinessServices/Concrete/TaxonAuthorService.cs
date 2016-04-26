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
    public class TaxonAuthorService : ITaxonAuthorService
    {
        private readonly UnitOfWork _unitOfWork;
        /// <summary>
        /// Public constructor.
        /// </summary>
        public TaxonAuthorService(UnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void AddAsync(TaxonAuthor entity)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<TaxonAuthor>> FindAllAsync(Expression<Func<TaxonAuthor, bool>> predicate = null)
        {
            throw new NotImplementedException();
        }

        public Task<TaxonAuthor> FindAsync(Expression<Func<TaxonAuthor, bool>> predicate = null)
        {
            throw new NotImplementedException();
        }

        public void Add(TaxonAuthor entity)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<Biodiversity.DataAccess.SqlDataTier.Entity.TaxonAuthor, TaxonAuthor>());
            var mapper = config.CreateMapper();
            //TaxonAuthor dto = mapper.Map<OrderDto>(order);
            throw new NotImplementedException();
        }

        public TaxonAuthor GetById(int Id)
        {
            throw new NotImplementedException();
        }

        public void Update(TaxonAuthor entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(TaxonAuthor entity)
        {
            throw new NotImplementedException();
        }

        public long Count()
        {
            throw new NotImplementedException();
        }

        public void AddRange(IEnumerable<TaxonAuthor> entities)
        {
            throw new NotImplementedException();
        }

        public void RemoveRange(IEnumerable<TaxonAuthor> entities)
        {
            throw new NotImplementedException();
        }

        public void SaveChanges()
        {
            throw new NotImplementedException();
        }

        public Task AddEntity(TaxonAuthor entity)
        {
            throw new NotImplementedException();
        }

        public Task UpdateEntity(TaxonAuthor entity)
        {
            throw new NotImplementedException();
        }

        public Task DeleteEntity(TaxonAuthor entity)
        {
            throw new NotImplementedException();
        }

        public Task CountEntity()
        {
            throw new NotImplementedException();
        }

        public Task<TaxonAuthor> GetEntityById(int Id)
        {
            throw new NotImplementedException();
        }

        public Task<TaxonAuthor> GetEntity(Expression<Func<TaxonAuthor, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<TaxonAuthor>> GetAllEntities()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<TaxonAuthor>> GetAllEntitiesFiltered(Expression<Func<TaxonAuthor, bool>> predicate = null)
        {
            throw new NotImplementedException();
        }
    }
}