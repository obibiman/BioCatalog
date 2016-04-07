using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Biodiversity.DataAccess.SqlDataTier.Entity;

namespace Biodiversity.Web.Models.Literature
{
    public class LiteratureListViewModel
    {
        public LiteratureListViewModel()
        {
            LiteratureAuthors = new HashSet<LiteratureAuthor>();
            TaxonLiteratures = new HashSet<TaxonLiterature>();
        }

        [Display(Name = "Id")]
        public int LiteratureId { get; set; }

        [Display(Name = "Ref. Year")]
        public string ReferenceYear { get; set; }

        [Display(Name = "Ref. Year Sub")]
        public string ReferenceYearSub { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Reference Date"),
         DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime? ReferenceDate { get; set; }

        [Display(Name = "Title")]
        public string TitleofArticleBooktitle { get; set; }

        [Display(Name = "In Ref. Num")]
        public int? InReferenceNumber { get; set; }

        public string Journal { get; set; }
        public string Volume { get; set; }
        public string Page { get; set; }
        public string Plate { get; set; }
        public string Publisher { get; set; }
        public string City { get; set; }
        public string Comment { get; set; }

        [Display(Name = "PDF Id")]
        public int? PdfId { get; set; }

        public byte[] TimeStamp { get; set; }

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

        public virtual ICollection<LiteratureAuthor> LiteratureAuthors { get; set; }
        public virtual ICollection<TaxonLiterature> TaxonLiteratures { get; set; }
    }
}