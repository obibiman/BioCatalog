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
    public class TaxonLiteratureService : ITaxonLiteratureService
    {
        private readonly UnitOfWork _unitOfWork;
        /// <summary>
        /// Public constructor.
        /// </summary>
        public TaxonLiteratureService(UnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void AddAsync(TaxonLiterature entity)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<TaxonLiterature>> FindAllAsync(Expression<Func<TaxonLiterature, bool>> predicate = null)
        {
            throw new NotImplementedException();
        }

        public Task<TaxonLiterature> FindAsync(Expression<Func<TaxonLiterature, bool>> predicate = null)
        {
            throw new NotImplementedException();
        }

        public void Add(TaxonLiterature entity)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<Biodiversity.DataAccess.SqlDataTier.Entity.TaxonLiterature, TaxonLiterature>());
            var mapper = config.CreateMapper();
            //TaxonLiterature dto = mapper.Map<OrderDto>(order);
            throw new NotImplementedException();
        }

        public TaxonLiterature GetById(int Id)
        {
            throw new NotImplementedException();
        }

        public void Update(TaxonLiterature entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(TaxonLiterature entity)
        {
            throw new NotImplementedException();
        }

        public long Count()
        {
            throw new NotImplementedException();
        }

        public void AddRange(IEnumerable<TaxonLiterature> entities)
        {
            throw new NotImplementedException();
        }

        public void RemoveRange(IEnumerable<TaxonLiterature> entities)
        {
            throw new NotImplementedException();
        }

        public void SaveChanges()
        {
            throw new NotImplementedException();
        }

        public Task AddEntity(TaxonLiterature entity)
        {
            throw new NotImplementedException();
        }

        public Task UpdateEntity(TaxonLiterature entity)
        {
            throw new NotImplementedException();
        }

        public Task DeleteEntity(TaxonLiterature entity)
        {
            throw new NotImplementedException();
        }

        public Task CountEntity()
        {
            throw new NotImplementedException();
        }

        public Task<TaxonLiterature> GetEntityById(int Id)
        {
            throw new NotImplementedException();
        }

        public Task<TaxonLiterature> GetEntity(Expression<Func<TaxonLiterature, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<TaxonLiterature>> GetAllEntities()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<TaxonLiterature>> GetAllEntitiesFiltered(Expression<Func<TaxonLiterature, bool>> predicate = null)
        {
            throw new NotImplementedException();
        }
    }
}