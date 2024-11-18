using CleanArchitectureTask.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CleanArchitectureTask.Domain.Configuration
{
    public class StudentWalletConfiguration : IEntityTypeConfiguration<StudentWallet>
    {
        public void Configure(EntityTypeBuilder<StudentWallet> builder)
        {
            builder.Property(w => w.Balance)
                   .IsRequired();
        }
    }
}
