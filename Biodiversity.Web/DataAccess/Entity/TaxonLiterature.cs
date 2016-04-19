using System.ComponentModel.DataAnnotations.Schema;

namespace Biodiversity.Web.DataAccess.Entity
{
    [Table("TaxonLiterature")]
    public class TaxonLiterature
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int TaxonLiteratureId { get; set; }

        public int TaxonId { get; set; }

        public int LiteratureId { get; set; }

        public virtual Literature Literature { get; set; }

        public virtual Taxon Taxon { get; set; }
    }
}