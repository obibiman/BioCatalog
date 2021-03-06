using System.ComponentModel.DataAnnotations.Schema;

namespace Biodiversity.DataAccess.SqlDataTier.Entity
{
    [Table("TaxonAuthor")]
    public class TaxonAuthor
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int TaxonAuthorId { get; set; }

        public int AuthorId { get; set; }

        public int TaxonId { get; set; }

        public short? Ordering { get; set; }

        public virtual Author Author { get; set; }

        public virtual Taxon Taxon { get; set; }
    }
}