using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Common.CQRS;
using Domain.Dto.Student;
using infrastructure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Shared.Entity.EntityOperation;
using Shared.OperationResult;

namespace Admin.ClassRoom.Student.Query.GetSubjectByYear;

public class GetStudentSubjectByYearHandler : OperationResult ,IQueryHandler<GetStudentSubjectByYearQuery>
{

    private ApplicationDbContext _context;

    public GetStudentSubjectByYearHandler(ApplicationDbContext context){

        _context=context;

    }
    public async Task<JsonResult> Handle(GetStudentSubjectByYearQuery request, CancellationToken cancellationToken)
    {
        
        var Subjects=_context
        .StudentSubjects
        .AsNoTracking()
        .Where(x=>x.StudentId==request.Id)
        .Where(x=>x.SubjectYear.ClassYear.YearId==request.YearId)
        .Select(x=>new GetAllStudentSubjectDto{


                Id=x.SubjectYear.TeacherSubject.Subject.Id,
                Name=x.SubjectYear.TeacherSubject.Subject.Name,
                Mark=x.Mark
        })
        .ToPagedList(request.PageNumber,request.PageSize);
        return Success(Subjects,"this is all your mark");
    }
}
