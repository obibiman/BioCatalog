using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity.Migrations;
using System.Data.SqlClient;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Biodiversity.DataAccess.SqlDataTier.Entity;
using Biodiversity.DataAccess.SqlDataTier.Repository.Interface;

namespace Biodiversity.DataAccess.SqlDataTier.Repository.Concrete
{
    public class LiteratureAuthorRepository : Repository<LiteratureAuthor>, ILiteratureAuthorRepository
    {
        protected Biocontext _context;

        public LiteratureAuthorRepository(Biocontext context) : base(context)
        {
            _context = context;
        }

        public Task<IEnumerable<LiteratureAuthor>> FindAllAsync(Expression<Func<LiteratureAuthor, bool>> predicate = null)
        {
            throw new NotImplementedException();
        }

        public Task<LiteratureAuthor> FindAsync(Expression<Func<LiteratureAuthor, bool>> predicate = null)
        {
            throw new NotImplementedException();
        }

        public void AddAsync(LiteratureAuthor entity)
        {
            var inputValue = new SqlParameter
            {
                ParameterName = "@SequenceName",
                SqlDbType = SqlDbType.NVarChar,
                Size = 50,
                Value = SequenceIdentifier.LiteratureAuthorSequence,
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
                .SqlQuery<int>("exec @SequenceOutput = sp_BiologyCatalogSequence @SequenceName, @SequenceValue OUT",
                    returnCode, inputValue, outParam)
                .FirstOrDefaultAsync();

            entity.LiteratureAuthorId = data.Result;
            _context.LiteratureAuthors.Add(entity);
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }

        public IEnumerable<LiteratureAuthor> GetAll(Expression<Func<LiteratureAuthor, bool>> predicate = null)
        {
            return _context.LiteratureAuthors.Where(predicate);
        }

        public LiteratureAuthor GetById(int id)
        {
            return Queryable.SingleOrDefault<LiteratureAuthor>(_context.LiteratureAuthors.Where(y => y.LiteratureAuthorId == id));
            //return (from auth in _context.LiteratureAuthors where auth.LiteratureAuthorId == id select auth).SingleOrDefault();
        }

        public IEnumerable<LiteratureAuthor> GetAll()
        {
            return _context.LiteratureAuthors.ToList();
            //return _context.LiteratureAuthors.ToList().OrderBy(y=>y.LastName);
        }

        public LiteratureAuthor Get(Expression<Func<LiteratureAuthor, bool>> predicate)
        {
            return _context.LiteratureAuthors.SingleOrDefault(predicate);
            //return _context.LiteratureAuthors.SingleOrDefault(predicate);
        }

        public new void Add(LiteratureAuthor entity)
        {
            var inputValue = new SqlParameter
            {
                ParameterName = "@SequenceName",
                SqlDbType = SqlDbType.NVarChar,
                Size = 50,
                Value = SequenceIdentifier.LiteratureAuthorSequence,
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
                .SqlQuery<int>("exec @SequenceOutput = sp_BiologyCatalogSequence @SequenceName, @SequenceValue OUT",
                    returnCode, inputValue, outParam)
                .FirstOrDefaultAsync();

            entity.LiteratureAuthorId = data.Result;
            _context.LiteratureAuthors.Add(entity);
            //SaveChanges();
        }

        public void Update(LiteratureAuthor entity)
        {
            var existingEntity = GetById(entity.LiteratureAuthorId);
            if (existingEntity == null)
            {
                return;
            }
            _context.LiteratureAuthors.AddOrUpdate(entity);
            //SaveChanges();
        }

        public void Delete(LiteratureAuthor entity)
        {
            _context.LiteratureAuthors.Remove(entity);
            //SaveChanges();
        }

        public long Count()
        {
            return _context.LiteratureAuthors.Count();
        }

        [Obsolete]
        public void Add_Old(LiteratureAuthor entity)
        {
            entity.LiteratureAuthorId =
                _context.Database.SqlQuery<int>("SELECT NEXT VALUE FOR dbo.LiteratureAuthorSequence;").FirstOrDefault();
            _context.LiteratureAuthors.Add(entity);
            //SaveChanges();
        }
    }
}