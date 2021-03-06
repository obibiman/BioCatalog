using System.ComponentModel.DataAnnotations.Schema;
using Biocontext.Web.DataAccess.Entity;

namespace Biodiversity.Web.DataAccess.Entity
{
    [Table("LiteratureAuthor")]
    public class LiteratureAuthor
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int LiteratureAuthorId { get; set; }

        public int LiteratureId { get; set; }

        public int AuthorId { get; set; }

        public short? Ordering { get; set; }

        public virtual Author Author { get; set; }

        public virtual Literature Literature { get; set; }
    }
}