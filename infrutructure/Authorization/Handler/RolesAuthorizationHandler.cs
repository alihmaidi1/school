using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authorization.Infrastructure;

namespace infrutructure.Authorization.Handler;

public class RolesAuthorizationHandler:AuthorizationHandler<RolesAuthorizationRequirement>
{
    public ApplicationDbContext DBContext;

    public RolesAuthorizationHandler(ApplicationDbContext DBContext) { 
        
        this.DBContext = DBContext; 
    }
    protected override async Task HandleRequirementAsync(AuthorizationHandlerContext context, RolesAuthorizationRequirement requirement)
    {
        if (context.User==null||context.User?.Identity?.IsAuthenticated==false)
        {
            context.Fail();
            return;

        }
        var Roles = requirement.AllowedRoles;

        var Id= context.User.Claims.FirstOrDefault(r=>r.Type==ClaimTypes.NameIdentifier).Value ;            
        // var UserRole= DBContext.GetAccountRoles(new Guid(Id));            
        // bool RolesExists=Roles.Any(r => UserRole.Any(ur => ur.Equals(r)));
            
        // if (RolesExists) {

            // context.Succeed(requirement);

        // }
        // else
        // {

            // context.Fail();
        // }

        
    }
}