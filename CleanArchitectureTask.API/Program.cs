
using CleanArchitectureTask.API.Extensions;
using CleanArchitectureTask.Application;
using CleanArchitectureTask.Infrastructure;

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





            var app = builder.Build();

            app.UseSwagger();
            app.UseSwaggerUI();
            app.UseHttpsRedirection();
            app.UseErrorHandler();
            app.MapControllers();
            app.Run();
        }
    }
}
