namespace TaskTracker.Application.Tasks.Commands.DeleteTask
{
    public class DeleteTaskResult(bool result, string? msg)
    {
        public string? Message { get; set; } = msg;
        public bool Success { get; set; } = result;
    }
}