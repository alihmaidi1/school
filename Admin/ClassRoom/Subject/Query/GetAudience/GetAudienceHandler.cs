using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Common.CQRS;
using Domain.Dto.Student;
using infrastructure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Shared.OperationResult;

namespace Admin.ClassRoom.Subject.Query.GetAudience;

public class GetAudienceHandler : OperationResult,IQueryHandler<GetAudienceQuery>
{

    private ApplicationDbContext _context;

    public GetAudienceHandler(ApplicationDbContext context){

        _context=context;
    }
    public async Task<JsonResult> Handle(GetAudienceQuery request, CancellationToken cancellationToken)
    {

        var StudentAudience=_context
        .Audiences
        .AsNoTracking()
        
        .Where(x=>x.SessionNumber==request.SessionNumber)
        .Where(x=>x.SubjectYear.SubjectId==request.SubjectId)
        .Where(x=>x.SubjectYear.ClassYear.YearId==request.YearId)
        .Select(x=>new GetStudentAudienceDto{


            Id=x.StudentId,
            Name=x.Student.Name,
            Image=x.Student.Image,
            Hash=x.Student.Hash,
            IsExists=x.IsExists
            


        })
        .Distinct()
        .ToList();

        return Success(StudentAudience,"this is all audiences");


    }
}
