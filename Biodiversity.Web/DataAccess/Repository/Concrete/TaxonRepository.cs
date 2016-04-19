using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Linq.Expressions;
using Biodiversity.Web.DataAccess.Entity;
using Biodiversity.Web.DataAccess.Repository.Interface;

namespace Biodiversity.Web.DataAccess.Repository.Concrete
{
    public class TaxonRepository : IRepository<Taxon>
    {
        private readonly Biocontext _context;

        public TaxonRepository(Biocontext context)
        {
            _context = context;
        }

        public IEnumerable<Taxon> GetAll(Expression<Func<Taxon, bool>> predicate = null)
        {
            return _context.Taxons.Where(predicate);
        }

        public Taxon GetById(int id)
        {
            return (from auth in _context.Taxons where auth.TaxonId == id select auth).SingleOrDefault();
        }

        public ICollection<Taxon> GetAll()
        {
            return _context.Taxons.ToList();
        }

        public Taxon Get(Expression<Func<Taxon, bool>> predicate)
        {
            return _context.Taxons.SingleOrDefault(predicate);
        }

        public void Add(Taxon entity)
        {
            entity.TaxonId =
                _context.Database.SqlQuery<int>("SELECT NEXT VALUE FOR dbo.TaxonSequence;").FirstOrDefault();
            _context.Taxons.Add(entity);
            _context.SaveChanges();
        }

        //public void Update(Taxon entity)
        //{
        //    _context.Taxons.Attach(entity);
        //    ((IObjectContextAdapter)_context).ObjectContext.ObjectStateManager.ChangeObjectState(entity,
        //        EntityState.Modified);
        //}

        public void Update(Taxon entity)
        {
            var entityId = entity.TaxonId;
            _context.Taxons.AddOrUpdate(entity);
            SaveChanges();
        }

        public void Delete(Taxon entity)
        {
            _context.Taxons.Remove(entity);
        }

        public long Count()
        {
            return _context.Taxons.Count();
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}