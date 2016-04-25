using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Biodiversity.DataAccess.SqlDataTier.Entity;

namespace Biodiversity.DataAccess.SqlDataTier.Repository.Interface
{
    public interface ILiteratureAuthorRepository : IRepository<LiteratureAuthor>
    {
        void AddAsync(LiteratureAuthor entity);
        Task<IEnumerable<LiteratureAuthor>> FindAllAsync(Expression<Func<LiteratureAuthor, bool>> predicate = null);
        Task<LiteratureAuthor> FindAsync(Expression<Func<LiteratureAuthor, bool>> predicate = null);
        void SaveChanges();
    }
}