using System;
using CQRS.Demo.API.CQRS.Commands;
using CQRS.Demo.API.CQRS.Handlers;

namespace CQRS.Demo.API.CQRS;

public static class DependencyInstallerCQRS
{
    public static IServiceCollection AddCQRSDependencies(this IServiceCollection services)
    {
        services.AddScoped<Dispatcher>();
      


        services.AddScoped<ICommandHandler<CriarNovaMarcaCommand>, CriarNovaMarcaCommandHandler>();

        return services;
    }
}
