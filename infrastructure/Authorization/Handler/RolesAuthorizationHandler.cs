using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authorization.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace infrastructure.Authorization.Handler;

public class RolesAuthorizationHandler:AuthorizationHandler<RolesAuthorizationRequirement>
{
    private readonly ApplicationDbContext _dbContext;

    public RolesAuthorizationHandler(ApplicationDbContext dbContext) { 
        
        this._dbContext = dbContext;
    }
    protected override  Task HandleRequirementAsync(AuthorizationHandlerContext context, RolesAuthorizationRequirement requirement)
    {
        if (context.User.Identity?.IsAuthenticated == false) context.Fail();
        var id = context.User.Claims.First(x=>x.Type==ClaimTypes.NameIdentifier).Value;
        var roles = requirement.AllowedRoles;
        
        var adminRole = _dbContext.Admins.Include(x => x.Role)
            .Select(x=>new
            {
                id=x.Id,
                role=x.Role.Name
                
            })
            .First(x=>x.id.Equals(id));
        if (roles.Any(x=>x.Equals(adminRole.role)))
            context.Succeed(requirement);
        else
            context.Fail();

        context.Succeed(requirement);
        return Task.CompletedTask;
    }
}