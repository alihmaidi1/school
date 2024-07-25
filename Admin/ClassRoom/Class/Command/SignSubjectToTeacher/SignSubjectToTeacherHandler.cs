using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using infrastructure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Shared.CQRS;
using Shared.OperationResult;

namespace Admin.ClassRoom.Class.Command.SignSubjectToTeacher;

public class SignSubjectToTeacherHandler : OperationResult,ICommandHandler<SignSubjectToTeacherCommand>
{

    private ApplicationDbContext _context;
    public SignSubjectToTeacherHandler(ApplicationDbContext context){

        _context=context;
    }
    public async Task<JsonResult> Handle(SignSubjectToTeacherCommand request, CancellationToken cancellationToken)
    {

        await _context
        .SubjectYears
        .Where(x=>x.SubjectId==request.SubjectId)
        .Where(x=>x.TeacherId==null)
        .ExecuteUpdateAsync(setter=>setter.SetProperty(x=>x.TeacherId,request.TeacherId),cancellationToken);
        return Success("subject assigned successfully");
    }
}
