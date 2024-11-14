using TaskTracker.Domain.Enums;
using TaskTracker.Domain.Exceptions;

namespace TaskTracker.Domain.Services
{
    public static class TaskStateValidator
    {
        private static readonly Dictionary<TaskState, TaskState[]> AllowedTransitions = new()
        {
            { TaskState.Todo, new[] { TaskState.Confirmed, TaskState.InProgress } },
            { TaskState.Confirmed, new[] { TaskState.InProgress } },
            { TaskState.InProgress, new[] { TaskState.InReview } },
            { TaskState.InReview, new[] { TaskState.Done } },
            { TaskState.Done, Array.Empty<TaskState>() } // No transitions from Done
        };

        public static bool CanTransition(TaskState currentState, TaskState newState)
        {
            return AllowedTransitions.TryGetValue(currentState, out var allowedStates) && allowedStates.Contains(newState);
        }

        public static void ValidateTransition(TaskState currentState, TaskState newState)
        {
            if (!CanTransition(currentState, newState))
            {
                throw new InvalidTaskStateTransitionException(currentState, newState);
            }
        }
    }
}