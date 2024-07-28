using Microsoft.Extensions.DependencyInjection;

namespace Halan.Application
{
    public static class ApplicationDIContainer
    {
        public static IServiceCollection AddApplicationDIContainer(this IServiceCollection services)
        {
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblyContaining(typeof(IMarkupAssemblyScanning)));

            return services;
        }
    }
}
