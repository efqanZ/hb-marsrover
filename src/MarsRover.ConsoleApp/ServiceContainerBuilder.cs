using MarsRover.Infrastructure;
using Microsoft.Extensions.DependencyInjection;

namespace MarsRover.ConsoleApp
{
    public static class ServiceContainerBuilder
    {
        public static void ConfigureServices(this IServiceCollection services)
        {
            services.AddInfrastructure();
        }
    }
}
