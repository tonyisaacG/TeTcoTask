namespace CleanArchitectureTask.Domain.Commons
{
    public abstract class BaseEntityWithKey<TKey>:IBaseEntity
    {
        public TKey Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public bool IsDeleted { get; set; }
        public string? ModifiedBy { get; set; }
    }
}
