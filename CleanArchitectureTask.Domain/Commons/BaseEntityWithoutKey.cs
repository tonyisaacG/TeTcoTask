
namespace CleanArchitectureTask.Domain.Commons
{
    public abstract class BaseEntityWithoutKey : IBaseEntity
    {
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public bool IsDeleted { get; set; }
        public string? ModifiedBy { get; set; }
    }
}
