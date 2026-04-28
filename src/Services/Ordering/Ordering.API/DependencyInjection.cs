namespace Ordering.API;

public static class DependencyInjection
{
    /// <summary>
    /// Provides an extension point to register API-related services into an <see cref="IServiceCollection"/>.
    /// </summary>
    /// <returns>The same <see cref="IServiceCollection"/> instance that was provided.</returns>
    public static IServiceCollection AddApiServices(this IServiceCollection services)
    {
        //services.AddCarter();

        return services;
    }

    /// <summary>
    /// Registers and configures API-related middleware and endpoints on the provided <see cref="WebApplication"/>.
    /// </summary>
    /// <param name="app">The application builder to configure.</param>
    /// <returns>The same <see cref="WebApplication"/> instance.</returns>
    public static WebApplication UseApiServices(this WebApplication app)
    {
        //app.MapCarter();

        return app;
    }
}
