using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using Common.CQRS;
using Domain.Dto.Teacher;
using infrastructure;
using Microsoft.AspNetCore.Mvc;
using Shared.OperationResult;

namespace Admin.Teacher.Teacher.Query.GetAllSubject;
public class GetAllSubjectHandler : OperationResult,IQueryHandler<GetAllSubjectQuery>
{

    private ApplicationDbContext _context;

    public GetAllSubjectHandler(ApplicationDbContext context){

        _context=context;
    }
    
    public async Task<JsonResult> Handle(GetAllSubjectQuery request, CancellationToken cancellationToken)
    {

        var Teahers=_context.
        TeacherSubjects
        .AsNoTracking()
        .Where(x=>x.SubjectId==request.SubjectId)
        .Select(x=>new GetAllTeacherNameDto{

            Id=x.Teacher.Id,
            Name=x.Teacher.Name
        })
        .ToList();
        return Success(Teahers);
    }
}
