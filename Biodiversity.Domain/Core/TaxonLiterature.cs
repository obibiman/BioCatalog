namespace Biodiversity.Domain
{
    public class TaxonLiterature
    {
        public int TaxonLiteratureId { get; set; }
        public int TaxonId { get; set; }
        public int LiteratureId { get; set; }
        public virtual Literature Literature { get; set; }
        public virtual Taxon Taxon { get; set; }
    }
}