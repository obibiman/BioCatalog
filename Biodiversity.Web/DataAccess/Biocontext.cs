using System.Data.Entity;
using Biocontext.Web.DataAccess.Entity;
using Biodiversity.Web.DataAccess.Entity;

namespace Biodiversity.Web.DataAccess
{
    public class Biocontext : DbContext
    {
        public Biocontext()
            : base("name=Biocontext")
        {
        }

        public virtual DbSet<Author> Authors { get; set; }
        public virtual DbSet<Literature> Literatures { get; set; }
        public virtual DbSet<LiteratureAuthor> LiteratureAuthors { get; set; }
        public virtual DbSet<Taxon> Taxons { get; set; }
        public virtual DbSet<TaxonAuthor> TaxonAuthors { get; set; }
        public virtual DbSet<TaxonLiterature> TaxonLiteratures { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Author>()
                .Property(e => e.TimeStamp)
                .IsFixedLength();

            modelBuilder.Entity<Author>()
                .HasMany(e => e.LiteratureAuthors)
                .WithRequired(e => e.Author)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Author>()
                .HasMany(e => e.TaxonAuthors)
                .WithRequired(e => e.Author)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Literature>()
                .Property(e => e.ReferenceYearSub)
                .IsUnicode(false);

            modelBuilder.Entity<Literature>()
                .Property(e => e.Page)
                .IsUnicode(false);

            modelBuilder.Entity<Literature>()
                .Property(e => e.TimeStamp)
                .IsFixedLength();

            modelBuilder.Entity<Literature>()
                .HasMany(e => e.LiteratureAuthors)
                .WithRequired(e => e.Literature)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Literature>()
                .HasMany(e => e.TaxonLiteratures)
                .WithRequired(e => e.Literature)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Taxon>()
                .Property(e => e.Parent)
                .IsUnicode(false);

            modelBuilder.Entity<Taxon>()
                .Property(e => e.TaxonComment)
                .IsUnicode(false);

            modelBuilder.Entity<Taxon>()
                .Property(e => e.TimeStamp)
                .IsFixedLength();

            modelBuilder.Entity<Taxon>()
                .HasMany(e => e.TaxonAuthors)
                .WithRequired(e => e.Taxon)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Taxon>()
                .HasMany(e => e.TaxonLiteratures)
                .WithRequired(e => e.Taxon)
                .WillCascadeOnDelete(false);
        }
    }
}