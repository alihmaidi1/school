using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using infrastructure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Shared.CQRS;
using Shared.OperationResult;
using Shared.Services.User;

namespace Teacher.Subject.Command.Add;

public class AddMarkToStudentHandler : OperationResult,ICommandHandler<AddMarkToStudentCommand>
{


    private ApplicationDbContext _context;

    private ICurrentUserService _currentUserService;
    public AddMarkToStudentHandler(ApplicationDbContext context,ICurrentUserService currentUserService){

        
            _currentUserService=currentUserService;
        _context=context;

    }
    public async Task<JsonResult> Handle(AddMarkToStudentCommand request, CancellationToken cancellationToken)
    {


        await _context
        .StudentSubjects
        .Where(x=>x.StudentId==request.StudentId)
        .Where(x=>x.SubjectYear.TeacherId==_currentUserService.GetUserid())
        .Where(x=>x.SubjectYear.SubjectId==request.SubjectId)        
        .ExecuteUpdateAsync(setter=>setter.SetProperty(x=>x.Mark,request.Mark));        
        return Success();
    }

}
