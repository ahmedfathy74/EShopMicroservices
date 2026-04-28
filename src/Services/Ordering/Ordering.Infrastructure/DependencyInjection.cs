using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Ordering.Infrastructure;

public static class DependencyInjection
{
    /// <summary>
    /// Registers infrastructure-level services into the provided service collection using application configuration.
    /// </summary>
    /// <param name="configuration">Application configuration from which the method reads the "Database" connection string.</param>
    /// <returns>The original <see cref="IServiceCollection"/> with infrastructure services registered.</returns>
    public static IServiceCollection AddInfrastructureServices
        (this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("Database");

        // Add services to the container.
      

        //services.AddScoped<IApplicationDbContext, ApplicationDbContext>();

        return services;
    }
}
