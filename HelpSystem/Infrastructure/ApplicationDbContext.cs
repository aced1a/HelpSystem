using Microsoft.EntityFrameworkCore;
using HelpSystem.Models;

namespace HelpSystem.Infrastructure
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Article> Articles { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Tag> Tags { get; set; }


        public ApplicationDbContext(DbContextOptions options)
            : base(options)
        { }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Category>(entity =>
            {
                entity.HasOne(c => c.Article)
                    .WithOne(a => a.Category);

                entity.HasOne(c => c.Parent)
                    .WithMany(c => c.Childs);
            });

            //builder.Entity<Book>(entity =>
            //{
            //    entity.HasMany(b => b.Authors)
            //        .WithMany(g => g.Books)
            //        .UsingEntity(e => e.ToTable("BookAuthor"));

            //    entity.HasMany(b => b.Genres)
            //        .WithMany(g => g.Books)
            //        .UsingEntity(e => e.ToTable("BookGenre"));
            //});
        }
    }
}
