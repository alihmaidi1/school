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
        var authentication = services.AddAuthentication(option=>{

            option.DefaultAuthenticateScheme=nameof(JwtSchema.Admin);
            option.DefaultChallengeScheme=nameof(JwtSchema.Admin);        
        });

        foreach (var item in  System.Enum.GetNames(typeof(JwtSchema)))
        {

            authentication.AddJwtBearer(item, options =>
            {
                
                    options.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
                    {

                        
                        ValidateIssuerSigningKey = true,
                        ValidateAudience = true,
                        ValidateIssuer = true,                    
                        ValidateLifetime = true,
                        ClockSkew=TimeSpan.Zero,
                        ValidIssuer = item,
                        ValidAudience = item,
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
         
            
        }
        
        return services;

    }

}