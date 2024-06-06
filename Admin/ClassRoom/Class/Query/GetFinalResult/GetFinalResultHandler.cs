using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Common.CQRS;
using Domain.Dto.ClassRoom;
using infrastructure;
using Microsoft.AspNetCore.Mvc;
using Shared.Entity.EntityOperation;
using Shared.OperationResult;

namespace Admin.ClassRoom.Class.Query;

public class GetFinalResultHandler : OperationResult ,IQueryHandler<GetFinalResultQuery>
{

    private ApplicationDbContext _context;

    public GetFinalResultHandler(ApplicationDbContext context){

        _context=context;
 
    }
    public async Task<JsonResult> Handle(GetFinalResultQuery request, CancellationToken cancellationToken)
    {

        var Result=_context
        .SubjectYears
        .Where(x=>x.ClassYear.YearId==request.YearId)
        .Where(x=>x.ClassYear.ClassId==request.ClassId)
        .Where(x=>!x.ClassYear.Status)
        .SelectMany(x=>x.StudentSubjects)
        .GroupBy(x=>x.Student)
        .Select(x=>new GetAllResultDto{

            Id=x.Key.Id,
            Name=x.Key.Name,
            Status=x.Count(x=>x.Mark>x.SubjectYear.TeacherSubject.Subject.MinDegree)>2,
            Precent=x.Sum(x=>x.Mark.Value)/x.Count(),
            Subjects=x.Select(y=>new GetAllResultDto.Subject{
                Id=y.SubjectYear.TeacherSubject.SubjectId,
                Name=y.SubjectYear.TeacherSubject.Subject.Name,
                Mark=y.Mark
            }).ToList()

            

            
        })
        .ToPagedList(request.PageNumber,request.PageSize);

        return Success(Result,"this is the result");
    }
}
