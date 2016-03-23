using System;

namespace Biodiversity.WebAPI.Service.Models.Taxon
{
    public class TaxonListModel
    {
        public int TaxonId { get; set; }
        public string TaxonName { get; set; }
        public string TaxonType { get; set; }
        public string Sex { get; set; }
        public short Level { get; set; }
        public string Parent { get; set; }
        public long? LevelUp { get; set; }
        public string TypeSpecies { get; set; }
        public string OrigGenus { get; set; }
        public string OrigSpelling { get; set; }
        public short? StartAge { get; set; }
        public short? EndAge { get; set; }
        public string GeologicAge { get; set; }
        public int? RecentGenera { get; set; }
        public int? FossilGenera { get; set; }
        public int? RecentSpecies { get; set; }
        public int? FossilSpecies { get; set; }
        public string Page { get; set; }
        public string Illustration { get; set; }
        public string TaxonComment { get; set; }
        public string Commonname { get; set; }
        public int? TypeForGroup { get; set; }
        public int? TaxonKey { get; set; }
        public int? PhylumKey { get; set; }
        public int? OldKey { get; set; }
        public long? OldId { get; set; }
        public int LevelUpOld { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}