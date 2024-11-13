using TaskTracker.Domain.Entities;

namespace TaskTracker.Domain.Interfaces
{
    public interface ITaskRepository
    {
        Task<List<TaskItem>> GetTasksAsync();
        Task AddTaskAsync(TaskItem task);
        Task UpdateTaskAsync(TaskItem task);
        Task DeleteTaskAsync(Guid taskId);
    }
}
