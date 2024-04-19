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

namespace Teacher.Auth.Logout;

public class LogoutTeacherHandler : OperationResult, ICommandHandler<LogoutTeacherCommand>
{

    private readonly ApplicationDbContext _context;
    private readonly ICurrentUserService _currentUserService;

    public LogoutTeacherHandler(ICurrentUserService currentUserService,ApplicationDbContext context){

        _context=context;
        _currentUserService=currentUserService;

    }


    public async Task<JsonResult> Handle(LogoutTeacherCommand request, CancellationToken cancellationToken)
    {

        await _context.AccountSessions.Where(x => x.Token==_currentUserService.Token).ExecuteDeleteAsync(cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);
        return Success(true,"you are logout successfully");
    }
}
