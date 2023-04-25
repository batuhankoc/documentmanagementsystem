using Microsoft.EntityFrameworkCore;

namespace dms.Entity.Entity
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<Document> Documents { get; set; }
        public DbSet<DocumentVersion> DocumentVersions { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<DocumentTag> DocumentTags { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DocumentTag>()
                .HasKey(dt => new { dt.DocumentId, dt.TagId });

            modelBuilder.Entity<DocumentTag>()
                .HasOne(dt => dt.Document)
                .WithMany(d => d.DocumentTags)
                .HasForeignKey(dt => dt.DocumentId);

            modelBuilder.Entity<DocumentTag>()
                .HasOne(dt => dt.Tag)
                .WithMany(t => t.DocumentTags)
                .HasForeignKey(dt => dt.TagId);
        }
    }
}
