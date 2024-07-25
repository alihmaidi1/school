using System.Data.Entity;
using Common.CQRS;
using Domain.Dto.Teacher;
using infrastructure;
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

        var StudentSubject=_context.ClassYears.AsNoTracking();

        if(request.YearId.HasValue){

            StudentSubject=StudentSubject.Where(x=>x.YearId==request.YearId);


        }else{


            StudentSubject=StudentSubject.Where(x=>x.Status);

        }


        var Result=StudentSubject.SelectMany(x=>x.SubjectYears)
        .Where(x=>x.TeacherId==request.Id)
        .Select(x=>new GetAllSubjectWithStudentTeacherDto{

            Id=x.Subject.Id,
            Name=x.Subject.Name,
            Students=x.StudentSubjects.Select(x=>new GetAllSubjectWithStudentTeacherDto.Student{

                Id=x.Student.Id,
                Name=x.Student.Name,
                Image=x.Student.Image,
                hash=x.Student.Hash

            }).Distinct().ToList()
        })
        .ToList();

        return Success(Result);

    }
}
