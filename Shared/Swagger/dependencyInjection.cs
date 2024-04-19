using System.Reflection;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using Swashbuckle.AspNetCore.SwaggerUI;

namespace Shared.Swagger;

public static class DependencyInjection
{
    
    public static IServiceCollection AddOpenApi(this IServiceCollection services,string AssemblyName)
        {
            
            services.AddSwaggerGen(option =>
            {


                // option.SchemaFilter<EnumSchemaFilter>();
                var xmlFile = $"{AssemblyName}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                option.IncludeXmlComments(xmlPath);


                //create  swagger document
                typeof(ApiGroupName).GetFields().Skip(1).ToList().ForEach(f =>
                {
                    var info = f.GetCustomAttribute<GroupInfoAttribute>();


                    var openApiInfo = new OpenApiInfo();
                    openApiInfo.Title = info?.Title;
                    openApiInfo.Version = info?.Version;
                    openApiInfo.Description = info?.Description;
                    option.SwaggerDoc(f.Name, openApiInfo);
                });


                option.DocInclusionPredicate((docName, apiDescription) =>
                {
                    if (!apiDescription.TryGetMethodInfo(out MethodInfo method)) return false;
                    if (docName == "All") return true;

                    var actionList = apiDescription.ActionDescriptor.EndpointMetadata.FirstOrDefault(x => x is ApiGroupAttribute);

                    if (docName == "NoGroup") return actionList == null ? true : false;
                    if (actionList != null)
                    {
                        //Determine whether to include this group
                        var actionFilter = actionList as ApiGroupAttribute;
                        return actionFilter.GroupName.Any(x => x.ToString().Trim() == docName);
                    }
                    return false;

                });

                option.CustomSchemaIds(s => s.FullName?.Replace("+", "."));

                option.AddSecurityDefinition("Bearer",new OpenApiSecurityScheme()
                {

                    Description = "JWT Authorization header using the Bearer scheme. Example: Authorization: Bearer {token}",
                    Type=SecuritySchemeType.Http,
                    In= ParameterLocation.Header,
                    Name = "Authorization",
                    Scheme = "Bearer",

                });


                option.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {

                              Reference = new OpenApiReference
                              {
                                Type=ReferenceType.SecurityScheme,
                                Id="Bearer"
                              }


                        },
                        new string[]{}


                    }


                });


            }).AddSwaggerGenNewtonsoftSupport();

            return services;

        }
        public static IApplicationBuilder ConfigureOpenApi(this IApplicationBuilder app)
        {
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                //Skip (1) is because the first fieldinfo of enum is a built-in int value
                typeof(ApiGroupName).GetFields().Skip(1).ToList().ForEach(f =>
                {
                    //Gets the attribute on the enumeration value
                    var info = f.GetCustomAttributes(typeof(GroupInfoAttribute), false).OfType<GroupInfoAttribute>().FirstOrDefault();
                    c.SwaggerEndpoint($"/swagger/{f.Name}/swagger.json",  f.Name);                    
                });

                c.DocExpansion(DocExpansion.None);
                
            });
            return app;
        }

    
}