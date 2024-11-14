using Microsoft.EntityFrameworkCore;

using TaskTracker.Domain.Entities;

namespace TaskTracker.Infrastructure.Data
{
    public class TaskDbContext(DbContextOptions<TaskDbContext> options) : DbContext(options)
    {
        public DbSet<TaskItem> Tasks { get; set; }
    }
}