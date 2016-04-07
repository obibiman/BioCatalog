using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Biodiversity.DataAccess.SqlDataTier.Entity;

namespace Biodiversity.Web.Models.Taxon
{
    public class TaxonDeleteViewModel
    {
        public TaxonDeleteViewModel()
        {
            TaxonAuthors = new HashSet<TaxonAuthor>();
            TaxonLiteratures = new HashSet<TaxonLiterature>();
        }

        [Display(Name = "Taxon Id")]
        public int TaxonId { get; set; }

        [Display(Name = "Taxon Name")]
        public string TaxonName { get; set; }

        [Display(Name = "Taxon Type")]
        public string TaxonType { get; set; }

        public string Sex { get; set; }
        public short Level { get; set; }
        public string Parent { get; set; }

        [Display(Name = "Level Up")]
        public long? LevelUp { get; set; }

        [Display(Name = "Type Species")]
        public string TypeSpecies { get; set; }

        [Display(Name = "Original Genius")]
        public string OrigGenus { get; set; }

        [Display(Name = "Original Spelling")]
        public string OrigSpelling { get; set; }

        [Display(Name = "Start Age")]
        public short? StartAge { get; set; }

        [Display(Name = "End Age")]
        public short? EndAge { get; set; }

        [Display(Name = "Geologic Age")]
        public string GeologicAge { get; set; }

        [Display(Name = "Recent Genera")]
        public int? RecentGenera { get; set; }

        [Display(Name = "Fossil Genera")]
        public int? FossilGenera { get; set; }

        [Display(Name = "Recent Species")]
        public int? RecentSpecies { get; set; }

        [Display(Name = "Fossil Species")]
        public int? FossilSpecies { get; set; }

        public string Page { get; set; }
        public string Illustration { get; set; }

        [Display(Name = "Taxon Comment")]
        public string TaxonComment { get; set; }

        [Display(Name = "Common Name")]
        public string Commonname { get; set; }

        [Display(Name = "Type for Group")]
        public int? TypeForGroup { get; set; }

        [Display(Name = "Taxon Key")]
        public int? TaxonKey { get; set; }

        [Display(Name = "Phylum Key")]
        public int? PhylumKey { get; set; }

        [Display(Name = "Old Key")]
        public int? OldKey { get; set; }

        [Display(Name = "Old Id")]
        public long? OldId { get; set; }

        [Display(Name = "Level Up Old")]
        public int LevelUpOld { get; set; }

        [Display(Name = "Modified By")]
        public string ModifiedBy { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Modified Date"),
         DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime? ModifiedDate { get; set; }

        [Display(Name = "Created By")]
        public string CreatedBy { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Created Date"),
         DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime CreatedDate { get; set; }

        public virtual ICollection<TaxonAuthor> TaxonAuthors { get; set; }
        public virtual ICollection<TaxonLiterature> TaxonLiteratures { get; set; }
    }
}