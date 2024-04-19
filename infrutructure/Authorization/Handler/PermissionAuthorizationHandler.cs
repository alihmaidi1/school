using System.Security.Claims;
using Domain.Entities.Manager.Admin;
using infrutructure.Authorization.Requirement;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace infrutructure.Authorization.Handler;

public class PermissionAuthorizationHandler:AuthorizationHandler<PermissionRequirement>
{
    private ApplicationDbContext DBContext ;
    private IHttpContextAccessor _httpContextAccessor;
    public PermissionAuthorizationHandler(ApplicationDbContext dbContext,IHttpContextAccessor _httpContextAccessor) {
            
        this.DBContext  = dbContext;

        this._httpContextAccessor = _httpContextAccessor;
    }

    protected override async Task HandleRequirementAsync(AuthorizationHandlerContext context, PermissionRequirement requirement)
    {
        if (context.User == null || context.User.Identity.IsAuthenticated == false) return;
        
        var id = context.User.Claims.FirstOrDefault(x=>x.Type==ClaimTypes.NameIdentifier).Value;

        var admin = DBContext.Admins
            .IgnoreQueryFilters()
            .Include(x=>x.Role)
            .Select(x=>new
            {
                id=x.Id,
                Permission=x.Role.Permissions
            })
            .First(x => x.id.Equals(new AdminID(new Guid(id))));
        var permissions = admin.Permission;
        var requiredPermission = requirement.Permission;
        if (permissions.Any(x => x.Equals(requiredPermission)))
            context.Succeed(requirement);
        else
            context.Fail();
    }
}