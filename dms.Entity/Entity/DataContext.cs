using Microsoft.EntityFrameworkCore;

namespace dms.Entity.Entity
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public virtual DbSet<Document> documents { get; set; }
        public virtual DbSet<Tag> Tags { get; set; }
        public virtual DbSet<DocumentTag> DocumentTags { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Document>(entity =>
            {
                entity.ToTable("documents");

                entity.Property(e => e.Id).HasColumnName("id");
                entity.Property(e => e.Name).HasMaxLength(255).HasColumnName("name");
                entity.Property(e => e.FileUrl).HasMaxLength(255).HasColumnName("fileurl");
                entity.Property(e => e.FileSize).HasColumnName("filesize");
                entity.Property(e => e.UploadDate).HasColumnType("timestamp without time zone").HasColumnName("uploaddate");
                entity.Property(e => e.FileType).HasMaxLength(255).HasColumnName("filetype");
                entity.Property(e => e.VersionNumber).HasColumnName("versionnumber");
            });

            modelBuilder.Entity<Tag>(entity =>
            {
                entity.ToTable("tags");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Name)
                    .HasMaxLength(255)
                    .HasColumnName("name");
            });

            modelBuilder.Entity<DocumentTag>(entity =>
            {
                entity.HasKey(e => new { e.DocumentId, e.TagId });

                entity.ToTable("documenttags");

                entity.Property(e => e.DocumentId).HasColumnName("documentid");
                entity.Property(e => e.TagId).HasColumnName("tagid");

                //entity.HasOne(d => d.Document)
                //    .WithMany(p => p.DocumentTags)
                //    .HasForeignKey(d => d.DocumentId)
                //    .OnDelete(DeleteBehavior.Cascade);

                //entity.HasOne(d => d.Tag)
                //    .WithMany(p => p.DocumentTags)
                //    .HasForeignKey(d => d.TagId)
                //    .OnDelete(DeleteBehavior.Cascade);
            });

        }
    }
}
