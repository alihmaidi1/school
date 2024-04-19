using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Common.CQRS;
using Dto.Admin.Teacher;
using infrastructure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Shared.OperationResult;

namespace Admin.Teacher.Teacher.Query.GetAllSubjectAndStudent;

public class GetAllSubjectAndStudentHandler : OperationResult ,IQueryHandler<GetAllSubjectAndStudentQuery>
{

    private ApplicationDbContext _context;
    public GetAllSubjectAndStudentHandler(ApplicationDbContext context){


        _context=context;
    }
    public async Task<JsonResult> Handle(GetAllSubjectAndStudentQuery request, CancellationToken cancellationToken)
    {

        var StudentsAndSubjects=_context
        .Teachers
        .AsNoTracking()
        .Include(x=>x.SubjectYears)
        .ThenInclude(x=>x.Subject)
        .Include(x=>x.SubjectYears)
        .ThenInclude(x=>x.Year)
        .Include(x=>x.SubjectYears)
        .ThenInclude(x=>x.StudentSubjects)
        .ThenInclude(x=>x.Student)
        .Include(x=>x.Subjects)
        .Select(x=>new GetAllSubjectAndStudentDto(){

            Id=x.Id,
            Name=x.Name,
            Email=x.Email,
            Image=x.Image!,
            Hash=x.Hash!,
            Subjects=x.Subjects.Select(y=>new GetAllSubjectAndStudentDto.Subject(){

                Id=y.Id,
                Name=y.Name,
                Years=y.SubjectYears.Select(z=>new GetAllSubjectAndStudentDto.Year(){

                    Id=z.Year.Id,
                    Name=z.Year.Date.ToString("yyyy"),
                    Students=z.StudentSubjects.Select(t=>new GetAllSubjectAndStudentDto.Student(){


                            Id=t.Student.Id,
                            Name=t.Student.Name,
                            Mark=t.Mark


                    }).ToList()


                }).ToList()

            }).ToList()

        })
        .First(x=>x.Id==request.Id);
        return Success(StudentsAndSubjects,"this is all data");

    }
}
