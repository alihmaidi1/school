using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using infrastructure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Shared.CQRS;
using Shared.Helper;
using Shared.OperationResult;
using Shared.Services.User;

namespace Parent.Auth.Command.ChangePassword;
public class ChangePasswordHandler : OperationResult ,ICommandHandler<ChangePasswordCommand>
{

    private ApplicationDbContext _context;
    private ICurrentUserService _currentUserService;
    public ChangePasswordHandler(ApplicationDbContext context,ICurrentUserService currentUserService){

        _currentUserService=currentUserService;
        _context=context;
    }
    public async Task<JsonResult> Handle(ChangePasswordCommand request, CancellationToken cancellationToken)
    {
        var parent=_currentUserService.GetUserid();
        await _context
        .Parents
        .Where(x=>x.Id==_currentUserService.GetUserid())
        .ExecuteUpdateAsync(setter=>setter.SetProperty(x=>x.Password,PasswordHelper.HashPassword(request.Password)),cancellationToken);
        return Success("password updated successfully");
    }
}
