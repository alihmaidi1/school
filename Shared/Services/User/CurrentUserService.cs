using System.Security.Claims;
using Microsoft.AspNetCore.Http;

namespace Shared.Services.User;

public class CurrentUserService : ICurrentUserService
{
    private readonly IHttpContextAccessor _httpContextAccessor;
    public CurrentUserService(IHttpContextAccessor httpContextAccessor)
    {
        _httpContextAccessor = httpContextAccessor;
        var value = httpContextAccessor.HttpContext?.User?.Claims?.FirstOrDefault(x=>x.Type==ClaimTypes.NameIdentifier)?.Value;
        if (value != null)
            UserId = Guid.Parse(value);
        
    }

    public Guid? UserId { get; init; }

    public string? Token => _httpContextAccessor.HttpContext?.Request?.Headers?.Authorization.ToString()?.Split(" ")[1];

}