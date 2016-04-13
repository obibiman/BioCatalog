using System.ComponentModel.DataAnnotations;

namespace Biodiversity.Web.Models.Literature
{
    public class AuthorPartialViewModel
    {
        [Display(Name = "ID")]
        public int AuthorId { get; set; }

        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Display(Name = "First Name")]
        public string FirstName { get; set; }
    }
}