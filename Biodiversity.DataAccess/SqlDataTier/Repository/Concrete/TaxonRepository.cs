using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity.Migrations;
using System.Data.SqlClient;
using System.Linq;
using System.Linq.Expressions;
using Biodiversity.DataAccess.SqlDataTier.Entity;
using Biodiversity.DataAccess.SqlDataTier.Repository.Interface;

namespace Biodiversity.DataAccess.SqlDataTier.Repository.Concrete
{
    public class TaxonRepository : Repository<Taxon>, ITaxonRepository
    {
        private readonly Biocontext _context;

        public TaxonRepository(Biocontext context) : base(context)
        {
            _context = context;
        }

        public IEnumerable<Taxon> GetAll(Expression<Func<Taxon, bool>> predicate = null)
        {
            return _context.Taxons.Where(predicate);
        }

        //public IEnumerable<Taxon> GetAll(Expression<Func<Taxon, bool>> predicate = null)
        //{
        //    return _context.Taxons.Where(predicate);
        //}

        public Taxon GetById(int id)
        {
            return (from auth in _context.Taxons where auth.TaxonId == id select auth).SingleOrDefault();
        }

        public IEnumerable<Taxon> GetAll()
        {
            return _context.Taxons.ToList();
        }

        public Taxon Get(Expression<Func<Taxon, bool>> predicate)
        {
            return _context.Taxons.SingleOrDefault(predicate);
        }

        public void Add(Taxon entity)
        {
            var inputValue = new SqlParameter
            {
                ParameterName = "@SequenceName",
                SqlDbType = SqlDbType.NVarChar,
                Size = 50,
                Value = SequenceIdentifier.TaxonSequence,
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

            entity.TaxonId = data.Result;
            entity.CreatedDate = DateTime.Now;
            entity.ModifiedDate = null;
            entity.ModifiedBy = string.Empty;
            entity.CreatedDate = DateTime.Now;
            entity.CreatedBy = "Admin";
            _context.Taxons.Add(entity);
            //SaveChanges();
        }

        public void Update(Taxon entity)
        {
            var existingEntity = GetById(entity.TaxonId);
            if (existingEntity == null)
            {
                return;
            }
            entity.ModifiedDate = DateTime.Now;
            entity.ModifiedBy = "Admin";
            _context.Taxons.AddOrUpdate(entity);
            //SaveChanges();
        }

        public void Delete(Taxon entity)
        {
            _context.Taxons.Remove(entity);
            //SaveChanges();
        }

        public long Count()
        {
            return _context.Taxons.Count();
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }

        [Obsolete]
        public void Add_Old(Taxon entity)
        {
            entity.TaxonId =
                _context.Database.SqlQuery<int>("SELECT NEXT VALUE FOR dbo.TaxonSequence;").FirstOrDefault();
            entity.CreatedDate = DateTime.Now;
            entity.CreatedBy = "Admin";
            _context.Taxons.Add(entity);
            //SaveChanges();
        }
    }
}