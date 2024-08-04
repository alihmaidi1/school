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
        .Where(x=>x.Id==request.Id)
        .Select(x=>new GetQuezwithQuestionAndDetailDto{



            Id=x.Id,
            Name=x.Name,
            StartAt=x.StartAt,
            EndAt=x.EndAt,
            
            Questions=x.Questions.Select(y=>new GetQuezwithQuestionAndDetailDto.Question{

                Id=y.Id,

                Score=y.Score,
                Name=y.Name,
                Answers=y.Answers.Select(z=>new  GetQuezwithQuestionAndDetailDto.Answer{

                        Id=z.Id,
                        IsCorrect=z.IsCorrect,
                        Name=z.Name

                }).ToList()
                


            }).ToList(),

            Students=x.EndAt>DateTimeOffset.UtcNow?new List<GetQuezwithQuestionAndDetailDto.Student>():x.StudentQuezs.Select(y=>new GetQuezwithQuestionAndDetailDto.Student{

                Id=y.StudentId,
                Name=y.Student.Name,
                Image=y.Student.Image,
                StudentQuezId=y.Id,
                Hash=y.Student.Hash,
                Precent=y.StudentAnswers.Where(x=>x.Answer.IsCorrect).Sum(x=>x.Answer.Question.Score)/y.Quez.Questions.Sum(x=>x.Score)

            }).ToList()



        })
        .FirstAsync();


        return Success(Quez,"this is your data");
    }
}
