using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Dto.ClassRoom;
using infrastructure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Shared.CQRS;
using Shared.OperationResult;

namespace Admin.ClassRoom.Class.Command.FinishYear;

public class FinishYearHandler : OperationResult,ICommandHandler<FinishYearCommand>
{

    private ApplicationDbContext _context;
    public FinishYearHandler(ApplicationDbContext context){

        _context=context;

    }
    public async Task<JsonResult> Handle(FinishYearCommand request, CancellationToken cancellationToken)
    {

        var Students=_context
        .ClassYears
        .AsNoTracking()
        .Where(x=>x.Id==request.ClassYearId)
        .SelectMany(x=>x.SubjectYears)
        .SelectMany(x=>x.StudentSubjects)
        .GroupBy(x=>x.Student)
        .Select(x=>new GetStudentWithStatusDto{

            Id=x.Key.Id,
            Level=x.Key.Level,
            Status=x.Select(x=>x.Mark<x.SubjectYear.TeacherSubject.Subject.MinDegree).Count()<2

        })
        .ToList();


        await _context
        .Students
        .Where(x=>Students.Where(x=>x.Status).Select(x=>x.Id).ToList().Contains(x.Id))
        .ExecuteUpdateAsync(setter=>setter.SetProperty(x=>x.Level,x=>x.Level+1),cancellationToken);        

        await _context
        .ClassYears
        .Where(x=>x.Id==request.ClassYearId)
        .ExecuteUpdateAsync(setter=>setter.SetProperty(x=>x.Status,false),cancellationToken);


        return Success("class year was finished successfully");
        
    }
}
