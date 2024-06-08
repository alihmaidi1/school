using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hangfire.Storage.Monitoring;
using infrastructure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Shared.CQRS;
using Shared.OperationResult;
using Shared.Services.User;

namespace Teacher.Student.Command.AddMark;

public class AddMarkHandler : OperationResult,ICommandHandler<AddMarkCommand>
{
    private ApplicationDbContext _context;
    private ICurrentUserService _currentUserService;
    public AddMarkHandler(ApplicationDbContext context,ICurrentUserService currentUserService){

        _context=context;
        _currentUserService=currentUserService;

    }
    public async Task<JsonResult> Handle(AddMarkCommand request, CancellationToken cancellationToken)
    {

        await _context
        .StudentSubjects
        .Where(x=>x.StudentId==request.StudentId)
        .Where(x=>x.SubjectYear.ClassYear.Status)
        .Where(x=>x.SubjectYear.TeacherSubject.SubjectId==request.SubjectId)
        .Where(x=>x.SubjectYear.TeacherSubject.TeacherId==_currentUserService.UserId)
        .ExecuteUpdateAsync(setter=>setter.SetProperty(x=>x.Mark,request.Mark),cancellationToken);

        return Success("mark updated successfully");
    }
}
