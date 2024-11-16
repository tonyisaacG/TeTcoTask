using CleanArchitectureTask.Domain.Commons;
using System.ComponentModel.DataAnnotations.Schema;

namespace CleanArchitectureTask.Domain.Entities
{
    public class Wallet : BaseEntityWithKey<int>
    {
        public int OwnerId { get; set; }
        public decimal Balance { get; set; }

        [ForeignKey(nameof(OwnerId))]
        public Student Student { get; set; }

        [ForeignKey(nameof(OwnerId))]
        public Parent Parent { get; set; }
    }
}
