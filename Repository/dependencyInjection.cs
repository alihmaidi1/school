using Microsoft.Extensions.DependencyInjection;
using Repository.Jwt;
using Repository.Jwt.Factory;
using Repository.Manager.Admin;
using Repository.Manager.RefreshToken;

namespace Repository;

public static class dependencyInjection
{
    public static IServiceCollection AddRepository(this IServiceCollection services)
    {


        services.AddTransient<IAdminRepository,AdminRepository>();
        services.AddTransient<ISchemaFactory,SchemaFactory>();
        services.AddTransient<IAdminRefreshTokenRepository,AdminRefreshTokenRepository>();

        return services;

        
    }

}