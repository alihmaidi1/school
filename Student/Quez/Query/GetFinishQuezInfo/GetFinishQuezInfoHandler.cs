using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Common.CQRS;
using Domain.Dto.Student;
using infrastructure;
using Microsoft.AspNetCore.Mvc;
using Shared.OperationResult;

namespace Student.Quez.Query.GetFinishQuezInfo;

public class GetFinishQuezInfoHandler : OperationResult,IQueryHandler<GetFinishQuezInfoQuery>
{

    private ApplicationDbContext _context;

    public GetFinishQuezInfoHandler(ApplicationDbContext context){

        _context=context;
    }
    public async Task<JsonResult> Handle(GetFinishQuezInfoQuery request, CancellationToken cancellationToken)
    {
        var Quez=_context
        .StudentQuezs
        .Where(x=>x.Id==request.StudentQuezId)
        .Select(x=>new GetStudentFinishQuezDto{

            Name=x.Quez.Name,
            Questions=x.Quez.Questions.Select(y=>new GetStudentFinishQuezDto.Question{

                Id=y.Id,
                Name=y.Name,
                Image=y.Image,
                Time=y.Time,
                Score=y.Score,
                Answers=y.Answers.Select(z=>new GetStudentFinishQuezDto.Answer(){

                    Id=z.Id,
                    Name=z.Name,
                    IsCorrect=z.IsCorrect,
                    IsSelected=z.StudentAnswers.Any(r=>r.StudentQuizId==request.StudentQuezId)


                }).ToList()
                
                



            }).ToList()

        })
        .First();

        return Success(Quez,"this is finish quez info");
    }
}
