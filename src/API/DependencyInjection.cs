using CQRS.Demo.API.CQRS;

namespace CQRS.Demo.API;

public static  class DependencyInjection
{

    public static IServiceCollection AddCQRSDependencies(this IServiceCollection services)
    {
        services.AddScoped<Dispatcher>();

        return services;
    }
}
