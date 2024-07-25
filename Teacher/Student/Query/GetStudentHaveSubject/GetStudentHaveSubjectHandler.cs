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
using Shared.Services.User;

namespace Teacher.Student.Query.GetStudentHaveSubject;

public class GetStudentHaveSubjectHandler : OperationResult,IQueryHandler<GetStudentHaveSubjectQuery>
{

    private ApplicationDbContext _context;
    private ICurrentUserService _currentUserService;
    public GetStudentHaveSubjectHandler(ApplicationDbContext context,ICurrentUserService currentUserService){

        _context=context;

        _currentUserService=currentUserService;
    }
    public async Task<JsonResult> Handle(GetStudentHaveSubjectQuery request, CancellationToken cancellationToken)
    {
        
        var StudentName=_context
        .SubjectYears
        .AsNoTracking()
        .Where(x=>x.TeacherId==_currentUserService.GetUserid())
        .Where(x=>x.SubjectId==request.SubjectId)
        .SelectMany(x=>x.StudentSubjects)
        .Select(x=>new GetStudentNameDto{

            Id=x.Student.Id,
            Name=x.Student.Name
        })
        .ToList();
        
        return Success(StudentName);
    }
}
