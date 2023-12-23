using infrutructure.Authorization.Requirement;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;

namespace infrutructure.Authorization.Handler;

public class PermissionAuthorizationHandler:AuthorizationHandler<PermissionRequirement>
{
    // public UserManager<Account> UserManager;
    public ApplicationDbContext DBContext ;

    // public PermissionAuthorizationHandler(UserManager<Account> UserManager, ApplicationDbContext DBContext) {
            
        // this.UserManager = UserManager;
        // this.DBContext  = DBContext;

    // }

    protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, PermissionRequirement requirement)
    {
        throw new NotImplementedException();
    }
}