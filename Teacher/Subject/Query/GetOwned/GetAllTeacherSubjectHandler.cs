using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Common.CQRS;
using Domain.Dto.ClassRoom;
using infrastructure;
using Microsoft.AspNetCore.Mvc;
using Shared.OperationResult;
using Shared.Services.User;

namespace Teacher.Subject.Query.GetOwned;

public class GetAllTeacherSubjectHandler : OperationResult,IQueryHandler<GetAllTeacherSubjectQuery>
{

    private ApplicationDbContext _context;

    private ICurrentUserService _currentUserService;

    public GetAllTeacherSubjectHandler(ApplicationDbContext context,ICurrentUserService currentUserService){

        _currentUserService=currentUserService;
        _context=context;
    }
    public async Task<JsonResult> Handle(GetAllTeacherSubjectQuery request, CancellationToken cancellationToken)
    {

        var Subjects=_context
        .TeacherSubjects
        .Where(x=>x.TeacherId==_currentUserService.GetUserid())
        .Where(x=>x.SubjectYears.Any(y=>y.ClassYear.Status))
        .Select(x=>new GetAllSubjectNameDto{

            Id=x.Subject.Id,
            Name=x.Subject.Name
        }).ToList();

        return Success(Subjects,"this is all active subject name");
    }
}
