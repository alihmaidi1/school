using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Common.ExtensionMethod;
using infrastructure;
using MailKit;
using Microsoft.AspNetCore.Mvc;
using Parent.Auth.Command.Login;
using Shared.CQRS;
using Shared.Helper;
using Shared.OperationResult;
using Shared.Services.Email;

namespace Parent.Auth.Command.Login;

public class LoginParentHandler : OperationResult,ICommandHandler<LoginParentCommand>
{

    private ApplicationDbContext _context;
    private Shared.Services.Email.IMailService _mailService;
    public LoginParentHandler(ApplicationDbContext context,Shared.Services.Email.IMailService mailService){

        _context=context;
        _mailService=mailService;
    }
    public async Task<JsonResult> Handle(LoginParentCommand request, CancellationToken cancellationToken)
    {

        var Parent=_context.Parents.FirstOrDefault(x=>x.Email==request.Email);
        if(Parent is null) return ValidationError("Email","this email is not exists im our data");
        if(!PasswordHelper.VerifyPassword(request.Password,Parent.Password)) return ValidationError("Password","Password Is Not Correct");
        var Code="123456";        
        Parent.Code=Code;
        Parent.SendEmail("Student Login Code",$"You Can Login To Your Account By This Code${Code}");

        await _context.SaveChangesAsync(cancellationToken);
        return Success("Code was sended to your email successfully");

    }
}
