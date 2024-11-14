using System.Diagnostics.CodeAnalysis;

using TaskTracker.Domain.Enums;
using TaskTracker.Domain.Services;

namespace TaskTracker.Domain.Entities
{
    public class TaskItem : BaseEntity
    {
        public required string Title { get; set; }
        public string? Description { get; set; } = string.Empty;
        public DateTime? DueDate { get; set; }
        public TaskState TaskState { get; private set; } = TaskState.Todo;

        public bool IsCompleted => TaskState == TaskState.Done;

        public TaskItem()
        {
        }

        [SetsRequiredMembers]
        public TaskItem(string title, string? description, DateTime? dueDate)
        {
            Title = title;
            Description = description;
            DueDate = dueDate;
            CreatedDate = DateTime.Now;
            UpdatedDate = DateTime.Now;
        }

        public void MarkAsCompleted()
        {
            UpdateStatus(TaskState.Done);
        }

        public void UpdateStatus(TaskState newState)
        {
            // Validate task state before update
            TaskStateValidator.ValidateTransition(TaskState, newState);

            TaskState = newState;
            UpdatedDate = DateTime.Now;
        }
    }
}