
using CleanArchitectureTask.API.Extensions;
using CleanArchitectureTask.Application;
using CleanArchitectureTask.Infrastructure;
using CleanArchitectureTask.Infrastructure.Common;

namespace CleanArchitectureTask.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.ApplicationLayer();
            builder.Services.InfrastructureLayer(builder.Configuration);
            builder.Services.ConfigureApiBehavior();
            builder.Services.ConfigureCorsPolicy();

            builder.Services.Configure<StmpSetting>(builder.Configuration.GetSection(Settings.Smtp));




            var app = builder.Build();

            app.UseSwagger();
            app.UseSwaggerUI();
            app.UseErrorHandler();
            app.UseCors();
            app.MapControllers();
            app.Run();
        }
    }
}
