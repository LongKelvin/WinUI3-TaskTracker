using TaskTracker.Domain.Enums;

namespace TaskTracker.Domain.Exceptions
{
    public class InvalidTaskStateTransitionException(TaskState current, TaskState attempted) :
        Exception($"Cannot transition from {current} to {attempted}.")
    {
    }
}
