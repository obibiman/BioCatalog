using System;
using System.Collections.Generic;
using Biodiversity.DataAccess.SqlDataTier.Entity;

namespace Biodiversity.Web.Models.Literature
{
    public class LiteratureDeleteViewModel
    {
        public LiteratureDeleteViewModel()
        {
            LiteratureAuthors = new HashSet<LiteratureAuthor>();
            TaxonLiteratures = new HashSet<TaxonLiterature>();
        }

        public int LiteratureId { get; set; }
        public string ReferenceYear { get; set; }
        public string ReferenceYearSub { get; set; }
        public DateTime? ReferenceDate { get; set; }
        public string TitleofArticleBooktitle { get; set; }
        public int? InReferenceNumber { get; set; }
        public string Journal { get; set; }
        public string Volume { get; set; }
        public string Page { get; set; }
        public string Plate { get; set; }
        public string Publisher { get; set; }
        public string City { get; set; }
        public string Comment { get; set; }
        public int? PdfId { get; set; }
        public byte[] TimeStamp { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public virtual ICollection<LiteratureAuthor> LiteratureAuthors { get; set; }
        public virtual ICollection<TaxonLiterature> TaxonLiteratures { get; set; }
    }
}