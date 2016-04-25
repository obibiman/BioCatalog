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
    public class TaxonAuthorRepository : Repository<TaxonAuthor>, ITaxonAuthorRepository
    {
        protected Biocontext _context;

        public TaxonAuthorRepository(Biocontext context) : base(context)
        {
            _context = context;
        }

        public Task<IEnumerable<TaxonAuthor>> FindAllAsync(Expression<Func<TaxonAuthor, bool>> predicate = null)
        {
            throw new NotImplementedException();
        }

        public Task<TaxonAuthor> FindAsync(Expression<Func<TaxonAuthor, bool>> predicate = null)
        {
            throw new NotImplementedException();
        }

        public void AddAsync(TaxonAuthor entity)
        {
            var inputValue = new SqlParameter
            {
                ParameterName = "@SequenceName",
                SqlDbType = SqlDbType.NVarChar,
                Size = 50,
                Value = SequenceIdentifier.TaxonAuthorSequence,
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

            entity.TaxonAuthorId = data.Result;
            _context.TaxonAuthors.Add(entity);
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }

        public IEnumerable<TaxonAuthor> GetAll(Expression<Func<TaxonAuthor, bool>> predicate = null)
        {
            return _context.TaxonAuthors.Where(predicate);
        }

        public TaxonAuthor GetById(int id)
        {
            return Queryable.SingleOrDefault<TaxonAuthor>(_context.TaxonAuthors.Where(y => y.TaxonAuthorId == id));
            //return (from auth in _context.TaxonAuthors where auth.TaxonAuthorId == id select auth).SingleOrDefault();
        }

        public IEnumerable<TaxonAuthor> GetAll()
        {
            return _context.TaxonAuthors.ToList();
            //return _context.TaxonAuthors.ToList().OrderBy(y=>y.LastName);
        }

        public TaxonAuthor Get(Expression<Func<TaxonAuthor, bool>> predicate)
        {
            return _context.TaxonAuthors.SingleOrDefault(predicate);
            //return _context.TaxonAuthors.SingleOrDefault(predicate);
        }

        public new void Add(TaxonAuthor entity)
        {
            var inputValue = new SqlParameter
            {
                ParameterName = "@SequenceName",
                SqlDbType = SqlDbType.NVarChar,
                Size = 50,
                Value = SequenceIdentifier.TaxonAuthorSequence,
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

            entity.TaxonAuthorId = data.Result;
            _context.TaxonAuthors.Add(entity);
            //SaveChanges();
        }

        public void Update(TaxonAuthor entity)
        {
            var existingEntity = GetById(entity.TaxonAuthorId);
            if (existingEntity == null)
            {
                return;
            }
            _context.TaxonAuthors.AddOrUpdate(entity);
            //SaveChanges();
        }

        public void Delete(TaxonAuthor entity)
        {
            _context.TaxonAuthors.Remove(entity);
            //SaveChanges();
        }

        public long Count()
        {
            return _context.TaxonAuthors.Count();
        }

        [Obsolete]
        public void Add_Old(TaxonAuthor entity)
        {
            entity.TaxonAuthorId =
                _context.Database.SqlQuery<int>("SELECT NEXT VALUE FOR dbo.TaxonAuthorSequence;").FirstOrDefault();
            _context.TaxonAuthors.Add(entity);
            //SaveChanges();
        }
    }
}