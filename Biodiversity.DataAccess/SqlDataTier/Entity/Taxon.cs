using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace Biodiversity.DataAccess.SqlDataTier.Entity
{
    [Table("Taxon")]
    public class Taxon
    {
        [SuppressMessage("Microsoft.Usage",
            "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Taxon()
        {
            TaxonAuthors = new HashSet<TaxonAuthor>();
            TaxonLiteratures = new HashSet<TaxonLiterature>();
        }

        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int TaxonId { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "Taxon Name")]
        public string TaxonName { get; set; }

        [Required]
        [StringLength(1)]
        [Display(Name = "Taxon Type")]
        public string TaxonType { get; set; }

        [StringLength(5)]
        public string Sex { get; set; }

        public short Level { get; set; }

        [StringLength(8000)]
        public string Parent { get; set; }

        public long? LevelUp { get; set; }

        [StringLength(1)]
        [Display(Name = "Type Species")]
        public string TypeSpecies { get; set; }

        [StringLength(50)]
        public string OrigGenus { get; set; }

        [StringLength(50)]
        public string OrigSpelling { get; set; }

        public short? StartAge { get; set; }

        public short? EndAge { get; set; }

        [StringLength(1)]
        public string GeologicAge { get; set; }

        public int? RecentGenera { get; set; }

        public int? FossilGenera { get; set; }

        public int? RecentSpecies { get; set; }

        public int? FossilSpecies { get; set; }

        [StringLength(20)]
        public string Page { get; set; }

        [StringLength(50)]
        public string Illustration { get; set; }

        public string TaxonComment { get; set; }

        [StringLength(50)]
        public string Commonname { get; set; }

        public int? TypeForGroup { get; set; }

        public int? TaxonKey { get; set; }

        public int? PhylumKey { get; set; }

        public int? OldKey { get; set; }

        public long? OldId { get; set; }

        public int LevelUpOld { get; set; }

        [Column(TypeName = "timestamp")]
        [MaxLength(8)]
        [Timestamp]
        public byte[] TimeStamp { get; set; }

        [StringLength(50)]
        [Display(Name = "Modified By")]
        public string ModifiedBy { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Modified Date"),
         DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime? ModifiedDate { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "Created By")]
        public string CreatedBy { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Created Date"),
         DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime CreatedDate { get; set; }

        [SuppressMessage("Microsoft.Usage",
            "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TaxonAuthor> TaxonAuthors { get; set; }

        [SuppressMessage("Microsoft.Usage",
            "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TaxonLiterature> TaxonLiteratures { get; set; }
    }
}