using TaskTracker.Domain.Entities;

namespace TaskTracker.Domain.Interfaces
{
    public interface ITaskRepository
    {
        Task<Guid> AddTaskAsync(TaskItem task);

        Task<bool> DeleteTaskAsync(Guid taskId);

        Task<TaskItem?> GetTaskByIdAsync(Guid id);

        Task<List<TaskItem>> GetTasksAsync();

        Task<TaskItem> UpdateTaskAsync(TaskItem task);
    }
}