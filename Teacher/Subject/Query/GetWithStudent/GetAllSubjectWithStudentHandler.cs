using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Common.CQRS;
using Domain.Dto.Teacher;
using infrastructure;
using Microsoft.AspNetCore.Mvc;
using Shared.OperationResult;
using Shared.Services.User;

namespace Teacher.Subject.Query.GetWithStudent;

public class GetAllSubjectWithStudentHandler : OperationResult, IQueryHandler<GetAllSubjectWithStudentQuery>
{

    private ApplicationDbContext _context;
    private ICurrentUserService _currentUserService;
    public GetAllSubjectWithStudentHandler(ApplicationDbContext context,ICurrentUserService currentUserService){

        _currentUserService=currentUserService;
        _context=context;
    }
    public async Task<JsonResult> Handle(GetAllSubjectWithStudentQuery request, CancellationToken cancellationToken)
    {
        var StudentSubject=_context
        .ClassYears
        .Where(x=>x.YearId==request.YearId)
        .SelectMany(x=>x.SubjectYears)
        .Where(x=>x.TeacherSubject.TeacherId==_currentUserService.UserId)
        .Select(x=>new GetAllSubjectWithStudentTeacherDto{

            Id=x.TeacherSubject.Subject.Id,
            Name=x.TeacherSubject.Subject.Name,
            Students=x.StudentSubjects.Select(x=>x.Student.Name).ToList()
        })
        .ToList();
        return Success(StudentSubject);
    }
}
