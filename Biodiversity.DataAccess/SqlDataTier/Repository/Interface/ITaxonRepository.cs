using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Biodiversity.DataAccess.SqlDataTier.Entity;

namespace Biodiversity.DataAccess.SqlDataTier.Repository.Interface
{
    public interface ITaxonRepository
    {
        void Add(Taxon entity);
        long Count();
        void Delete(Taxon entity);
        Taxon Get(Expression<Func<Taxon, bool>> predicate);
        ICollection<Taxon> GetAll();
        IEnumerable<Taxon> GetAll(Expression<Func<Taxon, bool>> predicate = null);
        Taxon GetById(int id);
        void SaveChanges();
        void Update(Taxon entity);
    }
}