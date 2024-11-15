using MediatR;

using Microsoft.AspNetCore.Mvc;

using TaskTracker.Application.Tasks.Commands.CreateTask;
using TaskTracker.Application.Tasks.Queries.GetTaskById;

namespace TaskTracker.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TaskController(IMediator mediator) : ControllerBase
    {
        private readonly IMediator _mediator = mediator;

        [HttpPost]
        public async Task<IActionResult> CreateTask([FromBody] CreateTaskCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetTask(Guid id)
        {
            var query = new GetTaskByIdQuery { TaskId = id };
            var result = await _mediator.Send(query);
            return Ok(result);
        }
    }
}