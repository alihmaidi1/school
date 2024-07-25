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

namespace Teacher.Quez.Query.GetAllQuezWithQuestionAndAnswer;

public class GetQuezWithquestionAndAnswerHandler : OperationResult,IQueryHandler<GetQuezWithQuestionAndAnswerQuery>
{
    private ApplicationDbContext _context;
    public GetQuezWithquestionAndAnswerHandler(ApplicationDbContext context){

        _context=context;

    }
    public async Task<JsonResult> Handle(GetQuezWithQuestionAndAnswerQuery request, CancellationToken cancellationToken)
    {
        var Quez=await _context
        .Quezs
        .AsNoTracking()
        .AsSplitQuery()
        .Select(x=>new GetQuezwithQuestionAndDetailDto{

            Id=x.Id,
            Name=x.Name,
            StartAt=x.StartAt,
            EndAt=x.EndAt,

            Questions=x.Questions.Select(y=>new GetQuezwithQuestionAndDetailDto.Question{

                Id=y.Id,
                Name=y.Name,
                Answers=y.Answers.Select(z=>new  GetQuezwithQuestionAndDetailDto.Answer{

                        Id=z.Id,
                        IsCorrect=z.IsCorrect,
                        Name=z.Name

                }).ToList()
                


            }).ToList()


        })
        .FirstAsync(x=>x.Id==request.Id);


        return Success(Quez,"this is your data");
    }
}
