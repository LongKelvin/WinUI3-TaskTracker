using MediatR;

namespace TaskTracker.Application.Tasks.Commands.CreateTask
{
    public record CreateTaskCommand : IRequest<Guid>
    {
        public required string Title { get; set; }
        public string? Description { get; set; }

        public DateTime? DueDate { get; set; }
    }
}