using MediatR;

using TaskTracker.Domain.Entities;
using TaskTracker.Domain.Interfaces;

namespace TaskTracker.Application.Tasks.Queries.GetTaskById
{
    public class GetTaskByIdHandler(ITaskRepository taskRepository) : IRequestHandler<GetTaskByIdQuery, TaskItem>
    {
        private readonly ITaskRepository _taskRepository = taskRepository;

        public async Task<TaskItem> Handle(GetTaskByIdQuery request, CancellationToken cancellationToken)
        {
            return await _taskRepository.GetTaskByIdAsync(request.TaskId);
        }
    }
}