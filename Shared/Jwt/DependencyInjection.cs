using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Shared.Enum;
using Shared.Exceptions;

namespace Shared.Jwt;

public static class DependencyInjection
{
    
    public static IServiceCollection AddJwtConfiguration(this IServiceCollection services, IConfiguration configuration)
    {



        var iJwtOption = configuration.GetSection("Jwt");
        services.Configure<JwtSetting>(iJwtOption);
        var authentication = services.AddAuthentication(options =>
        {
            options.DefaultAuthenticateScheme = "school";
            options.DefaultChallengeScheme = "school";
            options.DefaultScheme = "school";
        }).AddJwtBearer("school", options =>
        {

            options.SaveToken = true;
            options.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
            {

                ValidateIssuerSigningKey = true,
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateLifetime = true,
                ValidIssuer = iJwtOption["Issuer"],
                ValidAudience = iJwtOption["Audience"],
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(iJwtOption["Key"]??""))


            };
            options.Events = new JwtBearerEvents
            {
                    
                OnChallenge = context =>
                {
                    context.HandleResponse();
                    throw new UnAuthenticationException();
                    
                },
                    
                OnForbidden = context => throw new UnAuthorizationException()
            };




        });
        
        return services;

    }

}