using Microsoft.EntityFrameworkCore;

using TaskTracker.Application.Tasks.Commands.CreateTask;
using TaskTracker.Domain.Interfaces;
using TaskTracker.Infrastructure.Data;
using TaskTracker.Infrastructure.Repositories;

namespace TaskTracker.API
{
    public static class ServiceRegistration
    {
        public static void AddApplicationServices(this IServiceCollection services)
        {
            // Register MediatR
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(CreateTaskCommand).Assembly));
        }

        public static void AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            // Register DbContext
            services.AddDbContext<TaskDbContext>(options =>
                options.UseSqlite(configuration.GetConnectionString("DefaultConnection"))
                       .EnableSensitiveDataLogging()
                       .LogTo(Console.WriteLine));

            // Register Repositories
            services.AddScoped<ITaskRepository, TaskRepository>();
        }
    }
}