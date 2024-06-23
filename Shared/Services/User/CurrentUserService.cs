using System.Security.Claims;
using Microsoft.AspNetCore.Http;

namespace Shared.Services.User;

public class CurrentUserService : ICurrentUserService
{
    private readonly IHttpContextAccessor _httpContextAccessor;
    public CurrentUserService(IHttpContextAccessor httpContextAccessor)
    {

        _httpContextAccessor = httpContextAccessor;

    }



    public Guid? GetUserid(){
        
        var value = _httpContextAccessor.HttpContext?.User?.Claims?.FirstOrDefault(x=>x.Type==ClaimTypes.NameIdentifier)?.Value;
        if (value != null)
            UserId = Guid.Parse(value);

        return null;
        

    }

    private Guid? UserId { get; set; }

    public string? Token => _httpContextAccessor.HttpContext?.Request?.Headers?.Authorization.ToString()?.Split(" ")[1];

}