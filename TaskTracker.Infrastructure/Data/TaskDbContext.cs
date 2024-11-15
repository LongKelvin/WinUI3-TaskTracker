using Microsoft.EntityFrameworkCore;

using TaskTracker.Domain.Entities;

namespace TaskTracker.Infrastructure.Data
{
    public class TaskDbContext(DbContextOptions<TaskDbContext> options) : DbContext(options)
    {
        public DbSet<TaskItem> Tasks { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TaskItem>(entity =>
            {
                entity.Property(e => e.Id)
                      .HasConversion(
                          v => v.ToByteArray(),          // Save as BLOB
                          v => new Guid(v))        // Read back as Guid
                      .IsRequired();
                entity.Property(t => t.Title).IsRequired(); // NOT NULL
                entity.Property(t => t.CreatedDate).HasDefaultValueSql("CURRENT_TIMESTAMP");
            });

            base.OnModelCreating(modelBuilder);
        }
    }
}

