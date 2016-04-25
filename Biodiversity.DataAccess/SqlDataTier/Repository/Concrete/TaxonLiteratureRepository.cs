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
    public class TaxonLiteratureRepository : Repository<TaxonLiterature>, ITaxonLiteratureRepository
    {
        protected Biocontext _context;

        public TaxonLiteratureRepository(Biocontext context) : base(context)
        {
            _context = context;
        }

        public Task<IEnumerable<TaxonLiterature>> FindAllAsync(Expression<Func<TaxonLiterature, bool>> predicate = null)
        {
            throw new NotImplementedException();
        }

        public Task<TaxonLiterature> FindAsync(Expression<Func<TaxonLiterature, bool>> predicate = null)
        {
            throw new NotImplementedException();
        }

        public void AddAsync(TaxonLiterature entity)
        {
            var inputValue = new SqlParameter
            {
                ParameterName = "@SequenceName",
                SqlDbType = SqlDbType.NVarChar,
                Size = 50,
                Value = SequenceIdentifier.TaxonLiteratureSequence,
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

            entity.TaxonLiteratureId = data.Result;
            _context.TaxonLiteratures.Add(entity);
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }

        public IEnumerable<TaxonLiterature> GetAll(Expression<Func<TaxonLiterature, bool>> predicate = null)
        {
            return _context.TaxonLiteratures.Where(predicate);
        }

        public TaxonLiterature GetById(int id)
        {
            return Queryable.SingleOrDefault<TaxonLiterature>(_context.TaxonLiteratures.Where(y => y.TaxonLiteratureId == id));
            //return (from auth in _context.TaxonLiteratures where auth.TaxonLiteratureId == id select auth).SingleOrDefault();
        }

        public IEnumerable<TaxonLiterature> GetAll()
        {
            return _context.TaxonLiteratures.ToList();
            //return _context.TaxonLiteratures.ToList().OrderBy(y=>y.LastName);
        }

        public TaxonLiterature Get(Expression<Func<TaxonLiterature, bool>> predicate)
        {
            return _context.TaxonLiteratures.SingleOrDefault(predicate);
            //return _context.TaxonLiteratures.SingleOrDefault(predicate);
        }

        public new void Add(TaxonLiterature entity)
        {
            var inputValue = new SqlParameter
            {
                ParameterName = "@SequenceName",
                SqlDbType = SqlDbType.NVarChar,
                Size = 50,
                Value = SequenceIdentifier.TaxonLiteratureSequence,
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

            entity.TaxonLiteratureId = data.Result;
            _context.TaxonLiteratures.Add(entity);
            //SaveChanges();
        }

        public void Update(TaxonLiterature entity)
        {
            var existingEntity = GetById(entity.TaxonLiteratureId);
            if (existingEntity == null)
            {
                return;
            }
            _context.TaxonLiteratures.AddOrUpdate(entity);
            //SaveChanges();
        }

        public void Delete(TaxonLiterature entity)
        {
            _context.TaxonLiteratures.Remove(entity);
            //SaveChanges();
        }

        public long Count()
        {
            return _context.TaxonLiteratures.Count();
        }

        [Obsolete]
        public void Add_Old(TaxonLiterature entity)
        {
            entity.TaxonLiteratureId =
                _context.Database.SqlQuery<int>("SELECT NEXT VALUE FOR dbo.TaxonLiteratureSequence;").FirstOrDefault();
            _context.TaxonLiteratures.Add(entity);
            //SaveChanges();
        }
    }
}