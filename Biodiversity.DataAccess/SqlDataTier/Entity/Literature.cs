using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace Biodiversity.DataAccess.SqlDataTier.Entity
{
    [Table("Literature")]
    public class Literature
    {
        [SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Literature()
        {
            LiteratureAuthors = new HashSet<LiteratureAuthor>();
            TaxonLiteratures = new HashSet<TaxonLiterature>();
        }

        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int LiteratureId { get; set; }

        [Required]
        [StringLength(20)]
        public string ReferenceYear { get; set; }

        [StringLength(2)]
        public string ReferenceYearSub { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Reference Date"),
         DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime? ReferenceDate { get; set; }

        public string TitleofArticleBooktitle { get; set; }

        public int? InReferenceNumber { get; set; }

        [StringLength(255)]
        public string Journal { get; set; }

        [StringLength(50)]
        public string Volume { get; set; }

        [StringLength(100)]
        public string Page { get; set; }

        [StringLength(50)]
        public string Plate { get; set; }

        [StringLength(255)]
        public string Publisher { get; set; }

        [StringLength(50)]
        public string City { get; set; }

        [StringLength(255)]
        public string Comment { get; set; }

        public int? PdfId { get; set; }

        [Column(TypeName = "timestamp")]
        [MaxLength(8)]
        [Timestamp]
        public byte[] TimeStamp { get; set; }

        [StringLength(50)]
        public string ModifiedBy { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Modified Date"),
         DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime? ModifiedDate { get; set; }

        [Required]
        [StringLength(50)]
        public string CreatedBy { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Created Date"),
         DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime CreatedDate { get; set; }

        [SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<LiteratureAuthor> LiteratureAuthors { get; set; }

        [SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TaxonLiterature> TaxonLiteratures { get; set; }
    }
}