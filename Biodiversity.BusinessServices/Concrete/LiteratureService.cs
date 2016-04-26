using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Biodiversity.BusinessServices.Interfaces;
using Biodiversity.DataAccess.SqlDataTier.Repository.UnitOfWork;
using Biodiversity.Domain.Core;

namespace Biodiversity.BusinessServices.Concrete
{
    public class LiteratureService : ILiteratureService
    {
        private readonly UnitOfWork _unitOfWork;

        /// <summary>
        /// Public constructor.
        /// </summary>
        public LiteratureService(UnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void AddAsync(Literature entity)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Literature>> FindAllAsync(Expression<Func<Literature, bool>> predicate = null)
        {
            throw new NotImplementedException();
        }

        public Task<Literature> FindAsync(Expression<Func<Literature, bool>> predicate = null)
        {
            throw new NotImplementedException();
        }

        public void Add(Literature entity)
        {
            throw new NotImplementedException();
        }

        public Literature GetById(int Id)
        {
            throw new NotImplementedException();
        }

        public void Update(Literature entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(Literature entity)
        {
            throw new NotImplementedException();
        }

        public long Count()
        {
            throw new NotImplementedException();
        }

        public void AddRange(IEnumerable<Literature> entities)
        {
            throw new NotImplementedException();
        }

        public void RemoveRange(IEnumerable<Literature> entities)
        {
            throw new NotImplementedException();
        }

        public void SaveChanges()
        {
            throw new NotImplementedException();
        }

        public Task AddEntity(Literature entity)
        {
            throw new NotImplementedException();
        }

        public Task UpdateEntity(Literature entity)
        {
            throw new NotImplementedException();
        }

        public Task DeleteEntity(Literature entity)
        {
            throw new NotImplementedException();
        }

        public Task CountEntity()
        {
            throw new NotImplementedException();
        }

        public Task<Literature> GetEntityById(int Id)
        {
            throw new NotImplementedException();
        }

        public Task<Literature> GetEntity(Expression<Func<Literature, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Literature>> GetAllEntities()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Literature>> GetAllEntitiesFiltered(Expression<Func<Literature, bool>> predicate = null)
        {
            throw new NotImplementedException();
        }
    }
}
