using CleanArchitectureTask.Application.Interfaces.Repositories;
using CleanArchitectureTask.Application.Interfaces.Services;
using CleanArchitectureTask.Domain.Entities;
using CleanArchitectureTask.Infrastructure.Common;
using CleanArchitectureTask.Infrastructure.Persistence;
using CleanArchitectureTask.Infrastructure.Repositories;
using CleanArchitectureTask.Infrastructure.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

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
            services.AddScoped<IParentWalletRepository,ParentWalletRepository>();
            services.AddScoped<IStudentWalletRepository,StudentWalletRepository>();
            services.AddScoped<IMailService,MailService>();
            services.AddSingleton<IFileProvider>(provider => new FileProvider(Path.Combine(Directory.GetCurrentDirectory(),"wwwroot")));

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
