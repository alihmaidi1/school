using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Common.CQRS;
using Dto.Student.Student;
using infrastructure;
using Microsoft.AspNetCore.Mvc;
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
        .StudentSubjects
        .Where(x=>x.StudentId==request.Id)
        .Where(x=>x.SubjectYear.YearId==request.YearId)
        .Where(x=>x.SubjectYear.SubjectId==request.SubjectId)
        .SelectMany(x=>x.StudentQuezs)
        .Select(x=>new GetAllStudentQuezDto{

                Id=x.QuezId,
                Name=x.Quez.Name,
                Mark=x.StudentAnswers.Where(x=>x.Answer.IsCorrect).Sum(x=>x.Answer.Question.Score)
            
        })
        .ToList();
        return Success(quezes,"this is all quezes");
    }
}
