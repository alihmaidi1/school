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


        var StudentSubject=_context.ClassYears.AsNoTracking();
        if(request.YearId.HasValue){
            StudentSubject=StudentSubject.Where(x=>x.YearId==request.YearId);
        }else{
            StudentSubject=StudentSubject.Where(x=>x.Status);
        }
        var Result=StudentSubject.SelectMany(x=>x.SubjectYears)
        .Where(x=>x.TeacherId==_currentUserService.GetUserid())
        .Select(x=>new GetAllSubjectWithStudentTeacherDto{

            Id=x.Subject.Id,
            Name=x.Subject.Name,
            Students=x.StudentSubjects.Select(x=>new GetAllSubjectWithStudentTeacherDto.Student{

                Id=x.Student.Id,
                Name=x.Student.Name,
                Image=x.Student.Image
            }).ToList()
        })
        .ToList();
        return Success(Result);
    }
}
