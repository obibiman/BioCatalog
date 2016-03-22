using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Biodiversity.DataAccess.SqlDataTier.Entity;

namespace Biodiversity.DataAccess.SqlDataTier.Repository.Interface
{
    public interface ILiteratureRepository
    {
        void Add(Literature entity);
        long Count();
        void Delete(Literature entity);
        Literature Get(Expression<Func<Literature, bool>> predicate);
        ICollection<Literature> GetAll();
        IEnumerable<Literature> GetAll(Expression<Func<Literature, bool>> predicate = null);
        Literature GetById(int id);
        void SaveChanges();
        void Update(Literature entity);
    }
}