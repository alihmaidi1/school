using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Common.CQRS;
using Domain.Dto.Quez;
using infrastructure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Shared.OperationResult;

namespace Teacher.Quez.Query.GetStudentAnswer;

public class GetStudentAnswerHandler : OperationResult, IQueryHandler<GetStudentAnswerQuery>
{

    private ApplicationDbContext _context;
    public GetStudentAnswerHandler(ApplicationDbContext context){

        _context=context;

    }
    public async Task<JsonResult> Handle(GetStudentAnswerQuery request, CancellationToken cancellationToken)
    {

        var Answers=_context
        .StudentQuezs
        .AsNoTracking()
        .AsSplitQuery()
        .Where(x=>x.Id==request.StudentQuezId)
        .Select(x=>new StudentAnswerDto{

            Id=x.Quez.Id,
            Name=x.Quez.Name,
            StartAt=x.Quez.StartAt.ToString(),
            EndAt=x.Quez.EndAt,

            Questions=x.Quez.Questions.Select(y=>new StudentAnswerDto.Question{

                Id=y.Id,
                Name=y.Name,
                Score=y.Score,
                
                Image=y.Image,
                Answers=y.Answers.Select(z=>new StudentAnswerDto.Answer{

                    Id=z.Id,
                    Name=z.Name,
                    IsCorrect=z.IsCorrect,
                    IsSelect=z.StudentAnswers.Any(r=>r.StudentQuizId==request.StudentQuezId)

                }).ToList()


            }).ToList()

        }).First();

        

        return Success(Answers,"this is student answer");
    }
}
 