using CleanArchitectureTask.Domain.Commons;
using System.ComponentModel.DataAnnotations.Schema;

namespace CleanArchitectureTask.Domain.Entities
{
    public class StudentWallet : BaseEntityWithKey<int>
    {
        public int OwnerId { get; set; }
        public decimal Balance { get; set; }

        [ForeignKey(nameof(OwnerId))]
        public Student Student { get; set; }
    }
    
}
