using System.Reflection;
using FluentValidation;
using MarsRover.Core.Interfaces.Service;
using MarsRover.Infrastructure.Behaivors;
using MarsRover.Infrastructure.Services;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace MarsRover.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            services.AddScoped<IRoverService, RoverService>();
            services.AddScoped<IPlateauService, PlateauService>();

            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly())
                    .AddMediatR(Assembly.GetExecutingAssembly())
                    .AddTransient(typeof(IPipelineBehavior<,>), typeof(LoggingBehavior<,>))
                    .AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>))
                    .AddTransient(typeof(IPipelineBehavior<,>), typeof(PerformanceBehaviour<,>));

            return services;
        }
    }
}