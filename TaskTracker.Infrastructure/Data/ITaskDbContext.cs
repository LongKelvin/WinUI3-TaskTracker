using Microsoft.EntityFrameworkCore;

using TaskTracker.Domain.Entities;

namespace TaskTracker.Infrastructure.Data
{
    public interface ITaskDbContext
    {
        DbSet<TaskItem>? Tasks { get; set; }
    }
}