using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using infrastructure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Shared.CQRS;
using Shared.OperationResult;
using Shared.Services.Email;

namespace Student.Auth.Command.ForgetPassword;

public class ForgetPasswordHandler : OperationResult,ICommandHandler<ForgetPasswordCommand>
{   

    private ApplicationDbContext _context;

    private IMailService _mailService;
    public ForgetPasswordHandler(ApplicationDbContext context,IMailService mailService){

        _context=context;
        _mailService=mailService;
    }
    public async Task<JsonResult> Handle(ForgetPasswordCommand request, CancellationToken cancellationToken)
    {

        var code="123456";

        await _context
        .Students
        .Where(x=>x.Email==request.Email)
        .ExecuteUpdateAsync(setter=>setter.SetProperty(x=>x.ResetCode,code),cancellationToken);
        // _mailService.SendMail(request.Email,"reset password code",$"this is reset code {code}");
        return Success("reset code was sended to email successfully");
    }
}
