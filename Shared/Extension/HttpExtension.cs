using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Extensions;

namespace Shared.Extension;

public static class HttpExtension
{
    public static string GetBaseUri(this IHttpContextAccessor httpContextAccessor)
    {

        string fullUrl = httpContextAccessor.HttpContext.Request.GetDisplayUrl();
        string path = httpContextAccessor.HttpContext.Request.Path;
        return fullUrl.Split(path)[0];

    }
}