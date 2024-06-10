using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Common.ExtensionMethod;
using infrastructure;
using MailKit;
using Microsoft.AspNetCore.Mvc;
using Shared.CQRS;
using Shared.Helper;
using Shared.OperationResult;
using Shared.Services.Email;

namespace Student.Auth.Command.Login;

public class LoginStudentHandler : OperationResult,ICommandHandler<LoginStudentCommand>
{

    private ApplicationDbContext _context;
    private Shared.Services.Email.IMailService _mailService;
    public LoginStudentHandler(ApplicationDbContext context,Shared.Services.Email.IMailService mailService){

        _context=context;
        _mailService=mailService;
    }
    public async Task<JsonResult> Handle(LoginStudentCommand request, CancellationToken cancellationToken)
    {

        var Student=_context.Students.FirstOrDefault(x=>x.Email==request.Email);
        if(Student is null) return ValidationError("Email","this email is not exists im our data");
        if(!PasswordHelper.VerifyPassword(request.Password,Student.Password)) return ValidationError("Password","Password Is Not Correct");
        var Code=string.Empty.GenerateCode();        
        Student.Code=Code;
        await _context.SaveChangesAsync(cancellationToken);
        _mailService.SendMail(request.Email,"Student Login Code",$"You Can Login To Your Account By This Code${Code}");
        return Success("Code was sended to your email successfully");

    }
}
