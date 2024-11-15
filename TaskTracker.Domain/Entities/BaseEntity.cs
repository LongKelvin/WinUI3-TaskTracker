namespace TaskTracker.Domain.Entities
{
    public abstract class BaseEntity
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
    }
}
