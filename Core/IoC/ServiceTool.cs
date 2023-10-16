using Microsoft.Extensions.DependencyInjection;

namespace Core.IoC;
public class ServiceTool
{
    public static IServiceProvider ServiceProvider { get; private set; }

    public static IServiceCollection Create(IServiceCollection services)
    {
        ServiceProvider = services.BuildServiceProvider();
        return services;
    }
}
