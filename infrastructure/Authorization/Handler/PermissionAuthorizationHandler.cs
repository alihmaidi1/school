using System.Security.Claims;
using Domain.Entities.Manager.Admin;
using infrastructure.Authorization.Requirement;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace infrastructure.Authorization.Handler;

public class PermissionAuthorizationHandler:AuthorizationHandler<PermissionRequirement>
{
    public PermissionAuthorizationHandler(ApplicationDbContext dbContext,IHttpContextAccessor httpContextAccessor) {
            
    }

    protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, PermissionRequirement requirement)
    {


        
        if (!context.User.HasClaim(c =>c.Issuer == "Admin"))
        {
            context.Succeed(requirement);
            return Task.CompletedTask;
        }
        
        var requiredPermission = requirement.Permission;
        var accountPermission = context.User.Claims.FirstOrDefault(x=>x.Type==requiredPermission);
        if (accountPermission is null)
        {
         context.Fail();
        }
        
        context.Succeed(requirement);
        return Task.CompletedTask;
        
    }
}