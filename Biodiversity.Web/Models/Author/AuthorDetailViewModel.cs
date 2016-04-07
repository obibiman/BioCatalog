using System;
using System.ComponentModel.DataAnnotations;

namespace Biodiversity.Web.Models.Author
{
    public class AuthorDetailViewModel
    {
        [Display(Name = "ID")]
        public int AuthorId { get; set; }

        [Display(Name = "Abbr.")]
        public string Abbreviation { get; set; }

        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Display(Name = "Surname")]
        public string SurName { get; set; }

        public string Comment { get; set; }

        [Display(Name = "Modify By")]
        public string ModifiedBy { get; set; }

        [Display(Name = "Modified Date"),
         DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime? ModifiedDate { get; set; }

        public string CreatedBy { get; set; }

        [Display(Name = "Created Date"),
         DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime CreatedDate { get; set; }
    }
}