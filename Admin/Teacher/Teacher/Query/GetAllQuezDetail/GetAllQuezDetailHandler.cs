using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Common.CQRS;
using Domain.Dto.Quez;
using infrastructure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using Shared.OperationResult;

namespace Admin.Teacher.Teacher.Query.GetAllQuezDetail;

public class GetAllQuezDetailHandler : OperationResult,IQueryHandler<GetAllQuezDetailQuery>
{   

    private ApplicationDbContext _context;

    public GetAllQuezDetailHandler(ApplicationDbContext context){

        _context=context;
    }
    public async Task<JsonResult> Handle(GetAllQuezDetailQuery request, CancellationToken cancellationToken)
    {
        var Quez=await _context
        .Quezs
        .Select(x=>new GetQuezwithQuestionAndDetailDto{

            Id=x.Id,
            Name=x.Name,
            StartAt=x.StartAt,
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

        return Success(Quez,"this is quez info");
    }
}
