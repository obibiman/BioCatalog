using Biodiversity.DataAccess.SqlDataTier.Entity;

namespace Biodiversity.DataAccess.SqlDataTier.Repository.Interface
{
    public interface ILiteratureRepository : IRepository<Literature>
    {
        void SaveChanges();
    }
}