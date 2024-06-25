using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using Common.CQRS;
using Domain.Dto.Student;
using infrastructure;
using Microsoft.AspNetCore.Mvc;
using Shared.OperationResult;

namespace Student.Quez.Query.GetQuezInfo;
public class GetQuezInfoHandler : OperationResult,IQueryHandler<GetQuezInfoQuery>
{

    private ApplicationDbContext _context;

    public GetQuezInfoHandler(ApplicationDbContext context){

        _context=context;
    }
    public async Task<JsonResult> Handle(GetQuezInfoQuery request, CancellationToken cancellationToken)
    {

        var QuezInfo=_context
        .StudentQuezs
        .AsNoTracking()
        
        .Where(x=>x.Id==request.Id)
        .Select(x=>new GetQuezInfoDto{

            Name=x.Quez.Name,
            Quezs=x.Quez.Questions.Select(x=>new GetQuezInfoDto.Question{

                Id=x.Id,
                Name=x.Name,
                Time=x.Time,
                Image=x.Image,
                Answers=x.Answers.Select(x=>new GetQuezInfoDto.Answer{

                    Id=x.Id,
                    Name=x.Name

                }).ToList()
                

            }).ToList()
        })

        .First();
    
        return Success(QuezInfo,"this is quez info");
    }
}
