using CleanArchitectureTask.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CleanArchitectureTask.Domain.Configuration
{
    public class ParentWalletConfiguration : IEntityTypeConfiguration<ParentWallet>
    {
        public void Configure(EntityTypeBuilder<ParentWallet> builder)
        {
            builder.Property(w => w.Balance)
                   .IsRequired();
        }
    }
}
