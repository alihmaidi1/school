using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities.Student.Audience;
using infrastructure;
using Microsoft.AspNetCore.Mvc;
using Shared.CQRS;
using Shared.OperationResult;

namespace Teacher.Subject.Command.AddSession;

public class AddSessionHandler : OperationResult,ICommandHandler<AddSessionCommand>
{

    private ApplicationDbContext _context;
    public AddSessionHandler(ApplicationDbContext context){

        _context=context;

    }
    public async Task<JsonResult> Handle(AddSessionCommand request, CancellationToken cancellationToken)
    {
        var NotExistsStudent=_context
        .StudentSubjects
        .AsNoTracking()
        .Where(x=>!request.StudentIds.Contains(x.StudentId)&&x.SubjectYear.SubjectId==request.SubjectId&&x.SubjectYear.ClassYear.Status)
        .Select(x=>x.StudentId)
        .Distinct()
        .ToList();
        
        var LastSessionNumber=_context
        .Audiences
        .AsNoTracking()
        .OrderByDescending(x=>x.SessionNumber)        
        .FirstOrDefault(x=>x.SubjectYear.ClassYear.Status&&x.SubjectYear.SubjectId==request.SubjectId)?.SessionNumber??1;
        var SubjectYear=_context.SubjectYears.First(x=>x.ClassYear.Status&&x.SubjectId==request.SubjectId);


        List<Audience> audiences=new List<Audience>();
        audiences.AddRange(request.StudentIds.Select(x=>new Audience{

            StudentId=x,
            SessionNumber=LastSessionNumber,
            IsExists=true,
            SubjectYearId=SubjectYear.Id,
            Date=DateTime.UtcNow            


        }).ToList());
        audiences.AddRange(NotExistsStudent.Select(x=>new Audience{

            StudentId=x,
            SessionNumber=LastSessionNumber,
            IsExists=false,
            SubjectYearId=SubjectYear.Id,
            Date=DateTime.UtcNow            


        }).ToList());

        _context.Audiences.AddRange(audiences);
        await _context.SaveChangesAsync(cancellationToken);
        return Success();
    }
}
