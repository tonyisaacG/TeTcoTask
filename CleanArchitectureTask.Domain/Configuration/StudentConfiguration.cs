using CleanArchitectureTask.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CleanArchitectureTask.Domain.Configuration
{
    public class StudentConfiguration : IEntityTypeConfiguration<Student>
    {
        public void Configure(EntityTypeBuilder<Student> builder)
        {
            builder.HasOne(s => s.Wallet)
                   .WithOne(w => w.Student)
                   .HasForeignKey<StudentWallet>(w => w.OwnerId)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
