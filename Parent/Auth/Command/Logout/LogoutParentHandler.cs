using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using infrastructure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Shared.CQRS;
using Shared.OperationResult;
using Shared.Services.User;

namespace Parent.Auth.Command.Logout;

public class LogoutParentHandler : OperationResult,ICommandHandler<LogoutParentCommand>
{

    private ApplicationDbContext _context;
    private ICurrentUserService _currentUserService;
    public LogoutParentHandler(ApplicationDbContext context,ICurrentUserService currentUserService){

        _context=context;
        _currentUserService=currentUserService;
    }
    public async Task<JsonResult> Handle(LogoutParentCommand request, CancellationToken cancellationToken)
    {

        await _context.AccountSessions.Where(x => x.Token==_currentUserService.Token).ExecuteDeleteAsync(cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);
        return Success(true,"you are logout successfully");
    }
}
