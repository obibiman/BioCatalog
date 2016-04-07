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
    public class LiteratureRepository : Repository<Literature>, ILiteratureRepository
    {
        private readonly Biocontext _context;

        public LiteratureRepository(Biocontext context) : base(context)
        {
            _context = context;
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
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
            var inputValue = new SqlParameter
            {
                ParameterName = "@SequenceName",
                SqlDbType = SqlDbType.NVarChar,
                Size = 50,
                Value = SequenceIdentifier.LiteratureSequence,
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

            entity.LiteratureId = data.Result;
            entity.ModifiedDate = null;
            entity.ModifiedBy = string.Empty;
            entity.CreatedDate = DateTime.Now;
            entity.CreatedBy = "Admin";
            _context.Literatures.Add(entity);
            //SaveChanges();
        }

        public void Update(Literature entity)
        {
            var existingEntity = GetById(entity.LiteratureId);
            if (existingEntity == null)
            {
                return;
            }
            entity.ModifiedDate = DateTime.Now;
            entity.ModifiedBy = "Admin";
            _context.Literatures.AddOrUpdate(entity);
            //SaveChanges();
        }

        public void Delete(Literature entity)
        {
            var eId = entity.LiteratureId;
            var litAuthors =
                (from la in _context.LiteratureAuthors where la.LiteratureId == entity.LiteratureId select la)
                    .ToList();
            foreach (var litAuthor in litAuthors)
            {
                _context.LiteratureAuthors.Remove(litAuthor);
            }

            var taxonLiteratures =
                (from tl in _context.TaxonLiteratures where tl.LiteratureId == entity.LiteratureId select tl)
                    .ToList();
            foreach (var taxonLiterature in taxonLiteratures)
            {
                _context.TaxonLiteratures.Remove(taxonLiterature);
            }
            _context.Literatures.Remove(entity);
            //SaveChanges();
        }

        public long Count()
        {
            return _context.Literatures.Count();
        }

        [Obsolete]
        public void Add_Old(Literature entity)
        {
            entity.LiteratureId =
                _context.Database.SqlQuery<int>("SELECT NEXT VALUE FOR dbo.LiteratureSequence;").FirstOrDefault();
            entity.CreatedDate = DateTime.Now;
            entity.ModifiedDate = null;
            _context.Literatures.Add(entity);
            //SaveChanges();
        }
    }
}