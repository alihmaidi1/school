using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Common.CQRS;
using Domain.Dto.ClassRoom.Subject;
using infrastructure;
using Microsoft.AspNetCore.Mvc;
using Shared.CQRS;
using Shared.OperationResult;

namespace Admin.ClassRoom.Subject.Query.Get;

public class GetSubjectDetailHandler : OperationResult, IQueryHandler<GetSubjectDetailQuery>
{

    private ApplicationDbContext _context;

    public GetSubjectDetailHandler(ApplicationDbContext context){

        _context=context;
    }
    public async Task<JsonResult> Handle(GetSubjectDetailQuery request, CancellationToken cancellationToken)
    {
        var Subject=_context
        .SubjectYears
        .Where(x=>x.ClassYear.YearId==request.YearId)
        .Select(x=>new GetSubjectDetailDto{

            Id=x.TeacherSubject.Subject.Id,
            Name=x.TeacherSubject.Subject.Name,
            Degree=x.TeacherSubject.Subject.Degree,
            MinDegree=x.TeacherSubject.Subject.MinDegree,
            StudentNumber=x.StudentSubjects.Count()
            
        })
        .First();

        return Success(Subject,"this is subject info");
        
    }
}
