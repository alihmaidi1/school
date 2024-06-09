using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using infrastructure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Shared.CQRS;

namespace Admin.ClassRoom.Class.Command.StartYear;

public class StartYearHandler : ICommandHandler<StartYearCommand>
{


    private ApplicationDbContext _context;
    public StartYearHandler(ApplicationDbContext context){

        _context=context;

    }
    public Task<JsonResult> Handle(StartYearCommand request, CancellationToken cancellationToken)
    {

        var Class=_context
        .Classes
        .AsNoTracking()
        .Where(x=>x.Id==request.ClassId)
        .First();


        var Students=_context
        .Students
        .Where(x=>x.Level==Class.Level)
        .Where(x=>x.StudentSubjects.Where(y=>!y.SubjectYear.ClassYear.Status).Any())
        .Select(x=>x.Id)
        .ToList();

        // var ClassYear=_context
        // .ClassYears
        // .Where(x=>x.ClassId==request.YearId)
        // .OrderByDescending(x=>x.DateCreated)
        // .First();
        
        throw new NotImplementedException();
    }
}
