using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Ordering.Application;

public static class DependencyInjection
{
    /// <summary>
    /// Registers MediatR handlers and related application services from this assembly into the DI container.
    /// </summary>
    /// <returns>The same <see cref="IServiceCollection"/> instance after registration.</returns>
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        services.AddMediatR(cfg =>
        {
            cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly());
        });

        return services;
    }
}