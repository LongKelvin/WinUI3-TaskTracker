using MediatR;

using TaskTracker.Domain.Entities;

namespace TaskTracker.Application.Tasks.Queries.GetTaskById
{
    public record GetTaskByIdQuery : IRequest<TaskItem>
    {
        public Guid TaskId { get; set; }
    }
}