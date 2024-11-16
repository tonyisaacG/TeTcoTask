using CleanArchitectureTask.Domain.Commons;

namespace CleanArchitectureTask.Domain.Entities
{
    public class Student : BaseEntityWithKey<int>
    {
        public string NameAr { get; set; }
        public string NameEn { get; set; }
        public string NationalId { get; set; }
        public string Email { get; set; }
        public Wallet Wallet { get; set; }

    }
}
