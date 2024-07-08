using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities.ClassRoom;
using infrastructure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Shared.CQRS;
using Shared.OperationResult;

namespace Admin.ClassRoom.Class.Command.StartYear;

public class StartYearHandler : OperationResult,ICommandHandler<StartYearCommand>
{


    private ApplicationDbContext _context;
    public StartYearHandler(ApplicationDbContext context){

        _context=context;

    }
    public async Task<JsonResult> Handle(StartYearCommand request, CancellationToken cancellationToken)
    {

        var Class=_context
        .Classes
        .Include(x=>x.Subjects)
        .AsNoTracking()
        .Where(x=>x.Id==request.ClassId)
        .First();


        var Students=_context
        .Students
        .AsNoTracking()
        .Where(x=>x.Level==Class.Level)
        .Where(x=>x.StudentSubjects.Where(y=>!y.SubjectYear.ClassYear.Status).Any())
        .Select(x=>x.Id)
        .ToList();
        var ClassYear=new ClassYear{


            ClassId=request.ClassId,
            YearId=request.YearId,
            SubjectYears=Class.Subjects.Select(x=>new SubjectYear{

                SubjectId=x.Id

            }).ToList()

            
            
        };

        _context.ClassYears.Add(ClassYear);

        _context.SaveChanges();


        return Success();
    }
}
