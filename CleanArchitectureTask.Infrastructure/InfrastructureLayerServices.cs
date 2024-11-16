using CleanArchitectureTask.Application.Interfaces.Repositories;
using CleanArchitectureTask.Infrastructure.Common;
using CleanArchitectureTask.Infrastructure.Persistence;
using CleanArchitectureTask.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Text;

namespace CleanArchitectureTask.Infrastructure
{
    public static class InfrastructureLayerServices
    {
        public static IServiceCollection InfrastructureLayer(this IServiceCollection services,IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(option => option.UseSqlServer(configuration.GetConnectionString(Settings.ConnectionString)));
            services.AddScoped<IUnitOfWork,UnitOfWork>();
            services.AddScoped<IParentRepository,ParentRepository>();
            services.AddScoped<IStudentRepository,StudentRepository>();
            services.AddScoped<IWalletRepository,WalletRepository>();
            return services;
        }
        public static void EnsureMigration(this IServiceProvider services)
        {
            var serviceScope = services.CreateScope();
            var dataContext = serviceScope.ServiceProvider.GetService<ApplicationDbContext>();
            dataContext?.Database.EnsureCreated();
        }
    
    }
}
