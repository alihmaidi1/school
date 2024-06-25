using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Common.CQRS;
using Domain.Dto.Quez;
using Hangfire.Storage.Monitoring;
using infrastructure;
using Microsoft.AspNetCore.Mvc;
using Shared.Entity.EntityOperation;
using Shared.OperationResult;

namespace Teacher.Quez.Query.GetQuestion;

public class GetQuezQuestionHandler : OperationResult, IQueryHandler<GetQuezQuestionQuery>
{

    private ApplicationDbContext _context;
    public GetQuezQuestionHandler(ApplicationDbContext context){

        _context=context;

    }
    public async Task<JsonResult> Handle(GetQuezQuestionQuery request, CancellationToken cancellationToken)
    {

        var Quez=_context
        .Quezs        
        .Where(x=>x.Id==request.QuezId)
        .Select(x=>new GetQuezQuestionDetailDto{

            Id=x.Id,
            Name=x.Name,
            StartAt=x.StartAt,
            EndAt=x.EndAt,

            Questions=x.Questions.Select(y=>new GetQuezQuestionDetailDto.Question{

                Id=y.Id,
                Name=y.Name??"No Title"

            }).ToList()

        })
        .ToPagedList(request.PageNumber,request.PageSize);
        return Success(Quez ,"this is quez info");
    }
}
