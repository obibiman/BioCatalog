using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Biodiversity.DataAccess.SqlDataTier.Entity;

namespace Biodiversity.DataAccess.SqlDataTier.Repository.Interface
{
    public interface IAuthorRepository : IRepository<Author>
    {
        void AddAsync(Author entity);
        Task<IEnumerable<Author>> FindAllAsync(Expression<Func<Author, bool>> predicate = null);
        Task<Author> FindAsync(Expression<Func<Author, bool>> predicate = null);
        void SaveChanges();
    }
}