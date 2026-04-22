using System;
using CQRS.Demo.API.Data.Interfaces;
using CQRS.Demo.API.Data.Repositories;

namespace CQRS.Demo.API.Data;

public static class DependencyInstallerData
{
    public static IServiceCollection AddDataDependencies(this IServiceCollection services)
    {
        // Register your data-related dependencies here
        // For example:
        
        services.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));

        return services;
    }
}
