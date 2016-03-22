using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Biodiversity.DataAccess.SqlDataTier.Entity;

namespace Biodiversity.DataAccess.SqlDataTier.Repository.Interface
{
    public interface IAuthorRepository
    {
        void Add(Author entity);
        void AddAsync(Author entity);
        long Count();
        void Delete(Author entity);
        Task<ICollection<Author>> FindAllAsync(Expression<Func<Author, bool>> predicate = null);
        Task<Author> FindAsync(Expression<Func<Author, bool>> predicate = null);
        Author Get(Expression<Func<Author, bool>> predicate);
        ICollection<Author> GetAll();
        IEnumerable<Author> GetAll(Expression<Func<Author, bool>> predicate = null);
        Author GetById(int id);
        void SaveChanges();
        void Update(Author entity);
    }
}