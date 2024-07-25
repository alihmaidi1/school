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
        .Where(x=>x.StudentId==request.Id);
        if(request.YearId.HasValue){
            Subjects=Subjects.Where(x=>x.SubjectYear.ClassYear.YearId==request.YearId);
        }else{            
            Subjects=Subjects.Where(x=>x.SubjectYear.ClassYear.Status);
        }
        
        
        var result=Subjects.Select(x=>new GetAllStudentSubjectDto{


                Id=x.SubjectYear.Subject.Id,
                Name=x.SubjectYear.Subject.Name,
                Degree=x.Mark
        })
        .ToList();
        return Success(result,"this is all your mark");
    }
}
