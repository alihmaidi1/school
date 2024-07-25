using infrastructure;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Shared.CQRS;
using Shared.OperationResult;
using Shared.Services.User;

namespace Admin.Manager.Auth.Command.Logout;

public class LogoutAdminHandler:OperationResult, ICommandHandler<LogoutAdminCommand>
{

    private readonly ICurrentUserService _currentUserService;
    private readonly ApplicationDbContext _context;
    public LogoutAdminHandler(ICurrentUserService currentUserService,ApplicationDbContext context)
    {
        _currentUserService = currentUserService;
        _context = context;
    }
    
    public async Task<JsonResult> Handle(LogoutAdminCommand request, CancellationToken cancellationToken)
    {
        await _context.AccountSessions.Where(x => x.Token==_currentUserService.getToken()).ExecuteDeleteAsync(cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);
        return Success(true,"you are logout successfully");
    }
}