using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Biodiversity.BusinessServices.Interfaces;
using Biodiversity.DataAccess.SqlDataTier.Repository.UnitOfWork;
using Biodiversity.Domain.Core;

namespace Biodiversity.BusinessServices.Concrete
{
    public class TaxonService : ITaxonService
    {
        private readonly UnitOfWork _unitOfWork;

        /// <summary>
        /// Public constructor.
        /// </summary>
        public TaxonService(UnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void AddAsync(Taxon entity)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Taxon>> FindAllAsync(Expression<Func<Taxon, bool>> predicate = null)
        {
            throw new NotImplementedException();
        }

        public Task<Taxon> FindAsync(Expression<Func<Taxon, bool>> predicate = null)
        {
            throw new NotImplementedException();
        }

        public void Add(Taxon entity)
        {
            throw new NotImplementedException();
        }

        public Taxon GetById(int Id)
        {
            throw new NotImplementedException();
        }

        public void Update(Taxon entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(Taxon entity)
        {
            throw new NotImplementedException();
        }

        public long Count()
        {
            throw new NotImplementedException();
        }

        public void AddRange(IEnumerable<Taxon> entities)
        {
            throw new NotImplementedException();
        }

        public void RemoveRange(IEnumerable<Taxon> entities)
        {
            throw new NotImplementedException();
        }

        public void SaveChanges()
        {
            throw new NotImplementedException();
        }

        public Task AddEntity(Taxon entity)
        {
            throw new NotImplementedException();
        }

        public Task UpdateEntity(Taxon entity)
        {
            throw new NotImplementedException();
        }

        public Task DeleteEntity(Taxon entity)
        {
            throw new NotImplementedException();
        }

        public Task CountEntity()
        {
            throw new NotImplementedException();
        }

        public Task<Taxon> GetEntityById(int Id)
        {
            throw new NotImplementedException();
        }

        public Task<Taxon> GetEntity(Expression<Func<Taxon, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Taxon>> GetAllEntities()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Taxon>> GetAllEntitiesFiltered(Expression<Func<Taxon, bool>> predicate = null)
        {
            throw new NotImplementedException();
        }
    }
}