using Biodiversity.DataAccess.SqlDataTier.Entity;
using Biodiversity.DataAccess.SqlDataTier.Repository.Concrete;
using Biodiversity.DataAccess.SqlDataTier.Repository.Interface;

namespace Biodiversity.DataAccess.SqlDataTier.Repository.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly Biocontext _context;
        public IAuthorRepository AuthorRepository { get; }
        public ITaxonRepository TaxonRepository { get; }
        public ILiteratureRepository LiteratureRepository { get; }

        public UnitOfWork(Biocontext context)
        {
            _context = context;
            AuthorRepository = new AuthorRepository(_context);
            TaxonRepository = new TaxonRepository(_context);
            LiteratureRepository = new LiteratureRepository(_context);
        }

        public void Dispose()
        {
            _context.Dispose();
        }

        public int Complete()
        {
            return _context.SaveChanges();
        }

        //public void SaveChanges()
        //{
        //    _context.SaveChanges();
        //}
    }
}