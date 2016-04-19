using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using Biodiversity.Web.DataAccess.Entity;

namespace Biocontext.Web.DataAccess.Entity
{
    [Table("Author")]
    public class Author
    {
        [SuppressMessage("Microsoft.Usage",
            "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Author()
        {
            LiteratureAuthors = new HashSet<LiteratureAuthor>();
            TaxonAuthors = new HashSet<TaxonAuthor>();
        }

        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int AuthorId { get; set; }

        [Required]
        [StringLength(10)]
        public string Abbreviation { get; set; }

        [StringLength(50)]
        public string LastName { get; set; }

        [StringLength(30)]
        public string FirstName { get; set; }

        [StringLength(30)]
        public string SurName { get; set; }

        [StringLength(125)]
        public string Comment { get; set; }

        [Column(TypeName = "timestamp")]
        [MaxLength(8)]
        [Timestamp]
        public byte[] TimeStamp { get; set; }

        [StringLength(50), Display(Name = "Modified By")]
        public string ModifiedBy { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Modified Date"),
         DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime? ModifiedDate { get; set; }

        [Required]
        [StringLength(50), Display(Name = "Created By")]
        public string CreatedBy { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Created Date"),
         DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime CreatedDate { get; set; }

        [SuppressMessage("Microsoft.Usage",
            "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<LiteratureAuthor> LiteratureAuthors { get; set; }

        [SuppressMessage("Microsoft.Usage",
            "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TaxonAuthor> TaxonAuthors { get; set; }
    }
}