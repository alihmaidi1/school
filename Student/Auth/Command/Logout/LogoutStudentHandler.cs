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

namespace Student.Auth.Command.Logout;

public class LogoutStudentHandler : OperationResult,ICommandHandler<LogoutStudentCommand>
{

    private ApplicationDbContext _context;
    private ICurrentUserService _currentUserService;
    public LogoutStudentHandler(ApplicationDbContext context,ICurrentUserService currentUserService){

        _context=context;
        _currentUserService=currentUserService;
    }
    public async Task<JsonResult> Handle(LogoutStudentCommand request, CancellationToken cancellationToken)
    {

        await _context.AccountSessions.Where(x => x.Token==_currentUserService.getToken()).ExecuteDeleteAsync(cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);
        return Success(true,"you are logout successfully");
    }
}
