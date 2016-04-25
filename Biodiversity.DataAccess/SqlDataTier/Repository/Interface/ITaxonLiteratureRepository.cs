using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Biodiversity.DataAccess.SqlDataTier.Entity;

namespace Biodiversity.DataAccess.SqlDataTier.Repository.Interface
{
    public interface ITaxonLiteratureRepository : IRepository<TaxonLiterature>
    {
        void AddAsync(TaxonLiterature entity);
        Task<IEnumerable<TaxonLiterature>> FindAllAsync(Expression<Func<TaxonLiterature, bool>> predicate = null);
        Task<TaxonLiterature> FindAsync(Expression<Func<TaxonLiterature, bool>> predicate = null);
        void SaveChanges();
    }
}