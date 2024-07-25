using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Common.CQRS;
using Dto.Student.Student;
using infrastructure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Shared.OperationResult;

namespace Admin.Student.Student.Query.GetAllQuezByYearAndSubject;

public class GetAllQuezByYearAndSubjectHandler : OperationResult , IQueryHandler<GetAllQuezByYearAndSubjectQuery>
{

    private ApplicationDbContext _context;

    public GetAllQuezByYearAndSubjectHandler(ApplicationDbContext context){

        _context=context;

    }
    public async Task<JsonResult> Handle(GetAllQuezByYearAndSubjectQuery request, CancellationToken cancellationToken)
    {
        var quezes=_context
        .SubjectYears
        .AsNoTracking();
        if(request.YearId.HasValue){
            quezes=quezes.Where(x=>x.ClassYear.YearId==request.YearId);
        }else{
            quezes=quezes.Where(x=>x.ClassYear.Status);

        }        
        var result=quezes.SelectMany(x=>x.StudentSubjects.Where(x=>x.StudentId==request.Id).Select(x=>x.Student))
        .SelectMany(x=>x.StudentQuezs)
        .GroupBy(x=>x.Quez.SubjectYear.Subject)
        .Select(x=>new GetAllStudentQuezDto{

            Id=x.Key.Id,
            Name=x.Key.Name,
            Quezs=x.Select(y=>new GetAllStudentQuezDto.Quez{

                Id=y.Quez.Id,
                Name=y.Quez.Name,
                Mark=!y.StudentAnswers.Any()?null:(y.StudentAnswers.Where(x=>x.Answer.IsCorrect).Sum(x=>x.Answer.Question.Score)/y.Quez.Questions.Sum(x=>x.Score))

            }).ToList()

            

        })
        .ToList();
        return Success(result,"this is all quezes");

    }
}
