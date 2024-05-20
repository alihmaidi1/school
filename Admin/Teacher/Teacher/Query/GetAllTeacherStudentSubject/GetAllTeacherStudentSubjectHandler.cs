using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Common.CQRS;
using Domain.Dto.Teacher;
using infrastructure;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc;
using Shared.OperationResult;

namespace Admin.Teacher.Teacher.Query.GetAllTeacherStudentSubject;

public class GetAllTeacherStudentSubjectHandler : OperationResult, IQueryHandler<GetAllTeacherStudentSubjectQuery>
{
    private ApplicationDbContext _context;
    public GetAllTeacherStudentSubjectHandler(ApplicationDbContext context){

        _context=context;
    }
    public async Task<JsonResult> Handle(GetAllTeacherStudentSubjectQuery request, CancellationToken cancellationToken)
    {

        var StudentSubject=_context
        .ClassYears
        .Where(x=>x.YearId==request.YearId)
        .SelectMany(x=>x.SubjectYears)
        .Where(x=>x.TeacherId==request.TeacherId)
        .Select(x=>new GetAllSubjectWithStudentTeacherDto{

            Id=x.Teacher.Subject.Id,
            Name=x.Teacher.Subject.Name,
            Students=x.StudentSubjects.Select(x=>x.Student.Name).ToList()
        })
        .ToList();

        return Success(StudentSubject);
    }
}
