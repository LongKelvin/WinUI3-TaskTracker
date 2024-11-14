using Microsoft.EntityFrameworkCore;

using TaskTracker.Domain.Entities;
using TaskTracker.Domain.Interfaces;
using TaskTracker.Infrastructure.Data;

namespace TaskTracker.Infrastructure.Services
{
    public class TaskRepository(TaskDbContext dbContext) : ITaskRepository
    {
        private readonly TaskDbContext _dbContext = dbContext;

        public async Task<Guid> AddTaskAsync(TaskItem task)
        {
            await _dbContext.Tasks.AddAsync(task);
            await _dbContext.SaveChangesAsync();

            return task.Id;
        }

        public async Task<bool> DeleteTaskAsync(Guid taskId)
        {
            var taskItem = await _dbContext.Tasks.FindAsync(taskId);
            if (taskItem is null)
                return false;

            _dbContext.Tasks.Remove(taskItem);
            await _dbContext.SaveChangesAsync();

            return true;
        }

        public async Task<TaskItem?> GetTaskByIdAsync(Guid id)
        {
            return await _dbContext.Tasks.FindAsync(id);
        }

        public async Task<List<TaskItem>> GetTasksAsync()
        {
            return await _dbContext.Tasks.ToListAsync();
        }

        public async Task<TaskItem> UpdateTaskAsync(TaskItem task)
        {
            _dbContext.Tasks.Attach(task);
            _dbContext.Entry(task).State = EntityState.Modified;

            await _dbContext.SaveChangesAsync();
            return task;
        }
    }
}