using CleanArchitectureTask.Domain.Configuration;
using CleanArchitectureTask.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitectureTask.Infrastructure.Persistence
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new StudentConfiguration());
            modelBuilder.ApplyConfiguration(new ParentConfiguration());
            modelBuilder.ApplyConfiguration(new WalletConfiguration());
            base.OnModelCreating(modelBuilder);
        }
        public DbSet<Parent> Parents { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Wallet> Wallets { get; set; }
    }
}
