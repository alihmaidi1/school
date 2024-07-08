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

namespace Student.Auth.Command.ReSetCode;

public class ResetCodeHandler : OperationResult,ICommandHandler<ResetCodeCommand>
{

    private ApplicationDbContext _context;

    public ResetCodeHandler(ApplicationDbContext context){

        _context=context;

    }
    public async Task<JsonResult> Handle(ResetCodeCommand request, CancellationToken cancellationToken)
    {

        var code="123456";
        await _context.Students.Where(x=>x.Email==request.Email).ExecuteUpdateAsync(setter=>setter.SetProperty(x=>x.Code,code));
        return Success(true,"code was sended successfully");

    }
}
