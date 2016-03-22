namespace Biodiversity.Domain
{
    public class LiteratureAuthor
    {
        public int LiteratureAuthorId { get; set; }
        public int LiteratureId { get; set; }
        public int AuthorId { get; set; }
        public short? Ordering { get; set; }
        public virtual Author Author { get; set; }
        public virtual Literature Literature { get; set; }
    }
}