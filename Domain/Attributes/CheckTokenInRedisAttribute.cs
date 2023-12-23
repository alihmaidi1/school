using System.Net;
using System.Text.Json;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.DependencyInjection;
using Shared.OperationResult.Base;
using Shared.Redis;

namespace Domain.Attributes;

public class CheckTokenInRedisAttribute:AuthorizeAttribute,IAuthorizationFilter
{
    public void OnAuthorization(AuthorizationFilterContext context)
    {
        ICacheRepository CacheRepository = context.HttpContext.RequestServices.GetRequiredService<ICacheRepository>();
        var Token = context.HttpContext.Request.Headers.Authorization.ToString().Split(" ")[1];
        if (Token is not null && CacheRepository.IsExists("Token:" + Token))
        {

            return;

        }

        var response = context.HttpContext.Response;
        response.ContentType = "application/json";
        var Result = new OperationResultBase<string>() { };
        Result.Message = "Yor Are Not Authentcation";
        Result.StatusCode = (int)HttpStatusCode.Unauthorized;
        response.StatusCode = (int)HttpStatusCode.Unauthorized;
        var errors = JsonSerializer.Serialize(Result);
        response.WriteAsync(errors).Wait();


    }
}