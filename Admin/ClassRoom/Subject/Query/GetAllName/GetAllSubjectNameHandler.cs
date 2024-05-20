using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Common.CQRS;
using Domain.Dto.ClassRoom.Subject;
using infrastructure;
using Microsoft.AspNetCore.Mvc;
using Shared.OperationResult;

namespace Admin.ClassRoom.Subject.Query.GetAllName;

public class GetAllSubjectNameHandler : OperationResult,IQueryHandler<GetAllSubjectNameQuery>
{

    private ApplicationDbContext _context;
    public GetAllSubjectNameHandler(ApplicationDbContext context){

        _context=context;

    }
    public async Task<JsonResult> Handle(GetAllSubjectNameQuery request, CancellationToken cancellationToken)
    {
        var Subjects=_context.Subjects.Select(x=>new GetAllSubjectDto{

            Id=x.Id,
            SubjectName=x.Name
        }).ToList();

        return Success(Subjects);
    }
}
