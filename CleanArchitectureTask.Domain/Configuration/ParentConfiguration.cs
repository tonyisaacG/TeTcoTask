using CleanArchitectureTask.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CleanArchitectureTask.Domain.Configuration
{
    public class ParentConfiguration : IEntityTypeConfiguration<Parent>
    {
        public void Configure(EntityTypeBuilder<Parent> builder)
        {
            builder.HasOne(p => p.Wallet)
                   .WithOne(w => w.Parent)
                   .HasForeignKey<Wallet>(w => w.OwnerId)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
