using FaceRecognition.Models;
using Microsoft.EntityFrameworkCore;

namespace FaceRecognition.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Student> Students { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Student>(entity =>
                {
                    entity.Property(e => e.FaceEmbedding).HasConversion(
                        v => v == null ? null : string.Join(";", v.Select(f => f.ToString("F6"))),
                        v => v == null ? null : v.Split(';', StringSplitOptions.RemoveEmptyEntries).Select(float.Parse).ToArray()
                        );
                });
        }
    }
}
