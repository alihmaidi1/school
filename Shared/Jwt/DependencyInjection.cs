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
    
    public static IServiceCollection AddJwtConfigration(this IServiceCollection services, IConfiguration Configuration)
    {
            

        var Authentication=services.AddAuthentication(options =>
        {


            options.DefaultAuthenticateScheme = nameof(JwtSchema.Main);
            options.DefaultChallengeScheme = nameof(JwtSchema.Main);
            options.DefaultScheme = nameof(JwtSchema.Main);
        });

        
        
        foreach(var SchmeaName in System.Enum.GetNames(typeof(JwtSchema)))
        {
            var JwtOption = Configuration.GetSection(SchmeaName.ToString());

            Authentication.AddJwtBearer(SchmeaName.ToString(), options =>
            {
                options.SaveToken = true;
                options.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
                {

                    ValidateIssuerSigningKey = true,
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidIssuer = JwtOption["Issuer"],
                    ValidAudience = JwtOption["Audience"],
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(JwtOption["Key"]))


                };
                options.Events = new JwtBearerEvents
                {

                    OnChallenge = async context =>
                    {
                        context.HandleResponse();

                        throw new UnAuthenticationException();


                    },

                    OnForbidden = async context =>
                    {



                        throw new UnAuthorizationException();


                    }



                };



            });
        }

        return services;

    }

}