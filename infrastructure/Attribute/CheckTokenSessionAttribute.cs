using Domain.Entities.Account;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.DependencyInjection;
using Shared.Exceptions;
using Shared.Services.User;

namespace infrastructure.Attribute;

public class CheckTokenSessionAttribute: AuthorizeAttribute,IAuthorizationFilter
{
    
    public void OnAuthorization(AuthorizationFilterContext context)
    {
        ApplicationDbContext dbContext = context.HttpContext.RequestServices.GetRequiredService<ApplicationDbContext>();
        ICurrentUserService currentUserService = context.HttpContext.RequestServices.GetRequiredService<ICurrentUserService>();
        var accountSession = dbContext.AccountSessions.FirstOrDefault(x => x.Token ==currentUserService.Token&&x.Account.Status);
        if (accountSession is not null)
        {
            return;
        }
        throw new UnAuthenticationException();

    }
}