using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authorization.Infrastructure;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace infrutructure.Authorization.Handler;

public class RolesAuthorizationHandler:AuthorizationHandler<RolesAuthorizationRequirement>
{
    public ApplicationDbContext DBContext;
    private IHttpContextAccessor _httpContextAccessor;

    public RolesAuthorizationHandler(ApplicationDbContext DBContext,IHttpContextAccessor _httpContextAccessor) { 
        
        this.DBContext = DBContext;
        this._httpContextAccessor = _httpContextAccessor;
    }
    protected override async Task HandleRequirementAsync(AuthorizationHandlerContext context, RolesAuthorizationRequirement requirement)
    {
        if (context.User == null || context.User?.Identity?.IsAuthenticated == false) context.Fail();
        var id = context.User.Claims.FirstOrDefault(x=>x.Type==ClaimTypes.NameIdentifier).Value;
        var Roles = requirement.AllowedRoles;
        
        var AdminRole = DBContext.Admins.Include(x => x.Role)
            .Select(x=>new
            {
                id=x.Id,
                role=x.Role.Name
                
            })
            .FirstOrDefault(x=>x.id.Equals(id));
        if (Roles.Any(x=>x.Equals(AdminRole.role)))
            context.Succeed(requirement);
        else
            context.Fail();

        context.Succeed(requirement);  
    }
}