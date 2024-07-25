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

namespace Admin.Teacher.Teacher.Query.GetAllStudentAnswerInQuez;

public class GetAllStudentAnswerInQuezHandler : OperationResult,IQueryHandler<GetAllStudentAnswerInQuezQuery>
{

    private ApplicationDbContext _context;
    public GetAllStudentAnswerInQuezHandler(ApplicationDbContext context){
        _context=context;

    }

    public async Task<JsonResult> Handle(GetAllStudentAnswerInQuezQuery request, CancellationToken cancellationToken)
    {
        var Answers=_context
        .StudentQuezs
        .AsNoTracking()
        .AsSplitQuery()
        .Where(x=>x.StudentId==request.StudentId)
        .Where(x=>x.QuezId==request.QuezId)
        .Select(x=>new StudentAnswerDto{

            Id=x.Quez.Id,
            Name=x.Quez.Name,
            StartAt=x.Quez.StartAt.ToString(),
            EndAt=x.Quez.EndAt,
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

        return Success(Answers,"this is all your student answers");        

    }
}
