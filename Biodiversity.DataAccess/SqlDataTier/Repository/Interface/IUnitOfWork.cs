using System;

namespace Biodiversity.DataAccess.SqlDataTier.Repository.Interface
{
    public interface IUnitOfWork : IDisposable
    {
        ILiteratureRepository LiteratureRepository { get; }
        ITaxonRepository TaxonRepository { get; }
        IAuthorRepository AuthorRepository { get; }
        int Complete();
    }
}