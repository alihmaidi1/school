using System.Reflection;
using FluentValidation;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace Common;

public static class DependencyInjection
{
    
    public static IServiceCollection AddCommondependency(this IServiceCollection services)
    {

        services.AddMediatR(config => config.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
        services.AddValidatorsFromAssembly(AssemblyReference.CommonAssembly);

        return services;
    }
}