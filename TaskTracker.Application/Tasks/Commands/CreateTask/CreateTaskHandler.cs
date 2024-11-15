using MediatR;

using TaskTracker.Domain.Entities;
using TaskTracker.Domain.Interfaces;

namespace TaskTracker.Application.Tasks.Commands.CreateTask
{
    public class CreateTaskHandler(ITaskRepository taskRepository) : IRequestHandler<CreateTaskCommand, Guid>
    {
        private readonly ITaskRepository _taskRepository = taskRepository;

        public async Task<Guid> Handle(CreateTaskCommand request, CancellationToken cancellationToken)
        {
            var task = new TaskItem(request.Title, request.Description, request.DueDate);

            return await _taskRepository.AddTaskAsync(task);

        }
    }
}