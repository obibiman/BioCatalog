using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity.Core.Objects;
using System.Data.Entity.Migrations;
using System.Data.SqlClient;
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
            var inputValue = new SqlParameter
            {
                ParameterName = "@SequenceName",
                SqlDbType = SqlDbType.NVarChar,
                Size = 50,
                Value = SequenceIdentifier.AuthorSequence,
                Direction = ParameterDirection.Input
            };
            var outParam = new SqlParameter
            {
                ParameterName = "@SequenceValue",
                SqlDbType = SqlDbType.Int,
                Direction = ParameterDirection.Output
            };
            var returnCode = new SqlParameter
            {
                ParameterName = "@SequenceOutput",
                SqlDbType = SqlDbType.Int,
                Direction = ParameterDirection.Output
            };

            var data = _context.Database
                .SqlQuery<int>("exec @SequenceOutput = sp_BiologyCatalogSequence @SequenceName, @SequenceValue OUT", returnCode, inputValue, outParam)
                .FirstOrDefaultAsync();

            entity.AuthorId = data.Result;

            entity.ModifiedDate = null;
            entity.ModifiedBy = string.Empty;
            entity.CreatedDate = DateTime.Now;
            entity.CreatedBy = "Admin";

            _context.Authors.Add(entity);
            SaveChanges();
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
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
            var inputValue = new SqlParameter
            {
                ParameterName = "@SequenceName",
                SqlDbType = SqlDbType.NVarChar,
                Size = 50,
                Value = SequenceIdentifier.AuthorSequence,
                Direction = ParameterDirection.Input
            };
            var outParam = new SqlParameter
            {
                ParameterName = "@SequenceValue",
                SqlDbType = SqlDbType.Int,
                Direction = ParameterDirection.Output
            };
            var returnCode = new SqlParameter
            {
                ParameterName = "@SequenceOutput",
                SqlDbType = SqlDbType.Int,
                Direction = ParameterDirection.Output
            };

            var data = _context.Database
                .SqlQuery<int>("exec @SequenceOutput = sp_BiologyCatalogSequence @SequenceName, @SequenceValue OUT", returnCode, inputValue, outParam)
                .FirstOrDefaultAsync();

            entity.AuthorId = data.Result;

            entity.ModifiedDate = null;
            entity.ModifiedBy = string.Empty;
            entity.CreatedDate = DateTime.Now;
            entity.CreatedBy = "Admin";
            _context.Authors.Add(entity);
            SaveChanges();
        }

        [Obsolete]
        public void Add_Old(Author entity)
        {
            entity.AuthorId = _context.Database.SqlQuery<int>("SELECT NEXT VALUE FOR dbo.AuthorSequence;").FirstOrDefault();
            entity.CreatedDate = DateTime.Now;
            _context.Authors.Add(entity);
            SaveChanges();
        }

        public void Update(Author entity)
        {
            var existingEntity = GetById(entity.AuthorId);
            if (existingEntity == null)
            {
                return;
            }
            entity.ModifiedDate = DateTime.Now;
            _context.Authors.AddOrUpdate(entity);
            SaveChanges();
        }

        public void Delete(Author entity)
        {
            _context.Authors.Remove(entity);
            SaveChanges();
        }

        public long Count()
        {
            return _context.Authors.Count();
        }
    }
}