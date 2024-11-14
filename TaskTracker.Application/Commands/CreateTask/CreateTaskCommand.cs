using MediatR;

namespace TaskTracker.Application.Commands.CreateTask
{
    public class CreateTaskCommand : IRequest
    {
        public required string Title { get; set; }
        public string? Description { get; set; }

        public DateTime? DueDate { get; set; }
    }
}
