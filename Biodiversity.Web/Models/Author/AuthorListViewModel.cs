using System;

namespace Biodiversity.Web.Models.Author
{
    public class AuthorListViewModel
    {
        public int AuthorId { get; set; }
        public string Abbreviation { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string SurName { get; set; }
        public string Comment { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
    }

    //public class Author
    //{
    //    public Author()
    //    {
    //        LiteratureAuthors = new HashSet<LiteratureAuthor>();
    //        TaxonAuthors = new HashSet<TaxonAuthor>();
    //    }
    //    public int AuthorId { get; set; }
    //    public string Abbreviation { get; set; }
    //    public string LastName { get; set; }
    //    public string FirstName { get; set; }
    //    public string SurName { get; set; }
    //    public string Comment { get; set; }
    //    public byte[] TimeStamp { get; set; }
    //    public string ModifiedBy { get; set; }
    //    public DateTime? ModifiedDate { get; set; }
    //    public string CreatedBy { get; set; }
    //    public DateTime CreatedDate { get; set; }
    //    public virtual ICollection<LiteratureAuthor> LiteratureAuthors { get; set; }
    //    public virtual ICollection<TaxonAuthor> TaxonAuthors { get; set; }
    //}
}