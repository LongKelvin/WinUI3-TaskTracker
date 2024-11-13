namespace TaskTracker.Domain.Entities
{
    public class TaskItem
    {
        public Guid Id { get; set; }
        public required string Title { get; set; }
        public string Description { get; set; }
        public DateTime DueDate { get; set; }
        public bool IsCompleted { get; set; }
        public DateTime CreatedDate { get; set; }

        public TaskItem()
        {
            Title = string.Empty;
            Description = string.Empty;
        }
    }
}
