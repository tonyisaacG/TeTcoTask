using CleanArchitectureTask.Infrastructure.Common;
using CleanArchitectureTask.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace CleanArchitectureTask.API.Extensions
{
    public class ApplicationDbContextFactory : IDesignTimeDbContextFactory<ApplicationDbContext>
    {
        public ApplicationDbContext CreateDbContext(string[] args)
        {
            var configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json")
            .Build();
            var builder = new DbContextOptionsBuilder<ApplicationDbContext>()
            .UseSqlServer(configuration.GetConnectionString(Settings.ConnectionString),
             b => b.MigrationsAssembly("CleanArchitectureTask.API"));
            return new ApplicationDbContext(builder.Options);
        }

    }
}
