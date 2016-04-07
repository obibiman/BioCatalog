using Biodiversity.DataAccess.SqlDataTier.Entity;

namespace Biodiversity.DataAccess.SqlDataTier.Repository.Interface
{
    public interface ITaxonRepository : IRepository<Taxon>
    {
        Taxon GetById(int id);
        void SaveChanges();
    }
}