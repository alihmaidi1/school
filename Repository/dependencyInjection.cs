using System.Reflection;
using Common.Entity.Interface;
using Microsoft.Extensions.DependencyInjection;
using Repository.Jwt;
using Repository.Jwt.Factory;
using Repository.Manager.Admin;
using Repository.Manager.RefreshToken;
using Shared;

namespace Repository;

public static class dependencyInjection
{
    public static IServiceCollection AddRepository(this IServiceCollection services)
    {

        services.Scan(selector =>
            selector.FromAssemblies(Assembly.GetExecutingAssembly(),
                    SharedAssymbly.sharedAssemblyConst)
                .AddClasses(c => c.AssignableTo(typeof(basesuper)))
                .AsSelfWithInterfaces()
                .WithTransientLifetime()
        );

        
        // services.AddTransient<IAdminRepository,AdminRepository>();
        // services.AddTransient<ISchemaFactory,SchemaFactory>();
        // services.AddTransient<IAdminRefreshTokenRepository,AdminRefreshTokenRepository>();

        return services;

        
    }

}