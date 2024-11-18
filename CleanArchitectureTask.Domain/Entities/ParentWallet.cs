using CleanArchitectureTask.Domain.Commons;
using System.ComponentModel.DataAnnotations.Schema;

namespace CleanArchitectureTask.Domain.Entities
{
    public class ParentWallet : BaseEntityWithKey<int>
    {
        public int OwnerId { get; set; }
        public decimal Balance { get; set; }

        [ForeignKey(nameof(OwnerId))]
        public Parent Parent { get; set; }
    }
    
}
