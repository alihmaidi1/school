using Microsoft.OpenApi.Any;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace Shared.Swagger;

public class EnumSchemaFilter : ISchemaFilter
{
    public void Apply(OpenApiSchema schema, SchemaFilterContext context)
    {
        if (!context.Type.IsEnum)
        {
            return;
        }
        schema.Enum.Clear();
        foreach (var name in System.Enum.GetNames(context.Type))
        {
            schema.Enum.Add(new OpenApiString(name));
            
        }
    }
}