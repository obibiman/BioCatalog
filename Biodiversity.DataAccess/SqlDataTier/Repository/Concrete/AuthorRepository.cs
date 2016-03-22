using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Biodiversity.DataAccess.SqlDataTier.Entity;
using Biodiversity.DataAccess.SqlDataTier.Repository.Interface;

namespace Biodiversity.DataAccess.SqlDataTier.Repository.Concrete
{
    public class AuthorRepository : IRepository<Author>, IAuthorRepository
    {
        protected Biocontext _context;

        public AuthorRepository(Biocontext context)
        {
            _context = context;
        }

        public IEnumerable<Author> GetAll(Expression<Func<Author, bool>> predicate = null)
        {
            return _context.Authors.Where(predicate);
        }

        public Author GetById(int id)
        {
            return (from auth in _context.Authors where auth.AuthorId == id select auth).SingleOrDefault();
        }

        public ICollection<Author> GetAll()
        {
            return _context.Authors.ToList();
        }

        public Author Get(Expression<Func<Author, bool>> predicate)
        {
            return _context.Authors.SingleOrDefault(predicate);
        }

        public void Add(Author entity)
        {
            entity.AuthorId =
                _context.Database.SqlQuery<int>("SELECT NEXT VALUE FOR dbo.AuthorSequence;").FirstOrDefault();
            entity.CreatedDate = DateTime.Now;
            _context.Authors.Add(entity);
            _context.SaveChanges();
        }

        public void Update(Author entity)
        {
            var entityId = entity.AuthorId;
            entity.ModifiedDate = DateTime.Now;
            _context.Authors.AddOrUpdate(entity);
            SaveChanges();
        }

        //public void Update(Author entity)
        //{
        //    var entityId = entity.AuthorId;
        //    _context.Authors.Attach(entity);
        //    //((IObjectContextAdapter)_context).ObjectContext.ObjectStateManager.ChangeObjectState(entity,
        //    //    EntityState.Modified);

        //    SaveChanges();
        //    //_context.SaveChanges();
        //}

        public void Delete(Author entity)
        {
            _context.Authors.Remove(entity);
            _context.SaveChanges();
        }

        public long Count()
        {
            return _context.Authors.Count();
        }

        public Task<ICollection<Author>> FindAllAsync(Expression<Func<Author, bool>> predicate = null)
        {
            throw new NotImplementedException();
        }

        public Task<Author> FindAsync(Expression<Func<Author, bool>> predicate = null)
        {
            throw new NotImplementedException();
        }

        public void AddAsync(Author entity)
        {
            entity.AuthorId =
                _context.Database.SqlQuery<int>("SELECT NEXT VALUE FOR dbo.AuthorSequence;").FirstOrDefault();
            _context.Authors.Add(entity);
            _context.SaveChanges();
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}