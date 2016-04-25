using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Biodiversity.DataAccess.SqlDataTier.Entity;

namespace Biodiversity.DataAccess.SqlDataTier.Repository.Interface
{
    public interface ITaxonAuthorRepository : IRepository<TaxonAuthor>
    {
        void AddAsync(TaxonAuthor entity);
        Task<IEnumerable<TaxonAuthor>> FindAllAsync(Expression<Func<TaxonAuthor, bool>> predicate = null);
        Task<TaxonAuthor> FindAsync(Expression<Func<TaxonAuthor, bool>> predicate = null);
        void SaveChanges();
    }
}