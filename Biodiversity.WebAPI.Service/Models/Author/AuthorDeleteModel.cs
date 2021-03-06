using System;

namespace Biodiversity.WebAPI.Service.Models.Author
{
    public class AuthorDeleteModel
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
}