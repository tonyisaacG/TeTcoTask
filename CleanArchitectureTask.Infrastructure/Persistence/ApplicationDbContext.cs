using CleanArchitectureTask.Domain.Commons;
using CleanArchitectureTask.Domain.Configuration;
using CleanArchitectureTask.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitectureTask.Infrastructure.Persistence
{
    public partial class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            foreach( var type in GetEntityTypes() )
            {

                var method = SetGlobalQueryForBaseEntity.MakeGenericMethod(type);
                method.Invoke(this,new object[] { modelBuilder });

            }
            modelBuilder.ApplyConfiguration(new StudentConfiguration());
            modelBuilder.ApplyConfiguration(new ParentConfiguration());
            modelBuilder.ApplyConfiguration(new ParentWalletConfiguration());
            modelBuilder.ApplyConfiguration(new StudentWalletConfiguration());
            base.OnModelCreating(modelBuilder);
        }
        public DbSet<Parent> Parents { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<ParentWallet> ParentWallets { get; set; }
        public DbSet<StudentWallet> StudentWallets { get; set; }
      
    }
}
