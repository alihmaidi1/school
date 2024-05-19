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
        .StudentSubjects
        .AsNoTracking()
        .Where(x=>x.StudentId==request.StudentId)
        .SelectMany(x=>x.StudentQuezs)
        .Select(x=>new StudentAnswerDto{

            Id=x.Quez.Id,
            Name=x.Quez.Name,
            StartAt=x.Quez.StartAt.ToString(),
            Questions=x.StudentAnswers.Select(y=>new StudentAnswerDto.Question{

                Id=y.Answer.Question.Id,
                Name=y.Answer.Question.Name,
                Image=y.Answer.Question.Image,
                Answers=y.Answer.Question.Answers.Select(z=>new StudentAnswerDto.Answer{

                    Id=z.Id,
                    Name=z.Name,
                    IsCorrect=z.IsCorrect,
                    IsSelect=z.Id==y.AnswerId

                }).ToList()


            }).ToList()

        }).ToList();
        

        return Success(Answers,"this is student answer");
    }
}
