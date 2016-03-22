using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Linq.Expressions;
using Biodiversity.DataAccess.SqlDataTier.Entity;
using Biodiversity.DataAccess.SqlDataTier.Repository.Interface;

namespace Biodiversity.DataAccess.SqlDataTier.Repository.Concrete
{
    public class LiteratureRepository : IRepository<Literature>, ILiteratureRepository
    {
        private readonly Biocontext _context;

        public LiteratureRepository(Biocontext context)
        {
            _context = context;
        }

        public IEnumerable<Literature> GetAll(Expression<Func<Literature, bool>> predicate = null)
        {
            return _context.Literatures.Where(predicate);
        }

        public Literature GetById(int id)
        {
            return (from auth in _context.Literatures where auth.LiteratureId == id select auth).SingleOrDefault();
        }

        public ICollection<Literature> GetAll()
        {
            return _context.Literatures.ToList();
        }

        public Literature Get(Expression<Func<Literature, bool>> predicate)
        {
            return _context.Literatures.SingleOrDefault(predicate);
        }

        public void Add(Literature entity)
        {
            entity.LiteratureId =
                _context.Database.SqlQuery<int>("SELECT NEXT VALUE FOR dbo.LiteratureSequence;").FirstOrDefault();
            _context.Literatures.Add(entity);
            _context.SaveChanges();
        }

        //public void Update(Literature entity)
        //{
        //    _context.Literatures.Attach(entity);
        //    ((IObjectContextAdapter)_context).ObjectContext.ObjectStateManager.ChangeObjectState(entity,
        //        EntityState.Modified);
        //}

        public void Update(Literature entity)
        {
            var entityId = entity.LiteratureId;
            _context.Literatures.AddOrUpdate(entity);
            SaveChanges();
        }

        public void Delete(Literature entity)
        {
            _context.Literatures.Remove(entity);
        }

        public long Count()
        {
            return _context.Literatures.Count();
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}