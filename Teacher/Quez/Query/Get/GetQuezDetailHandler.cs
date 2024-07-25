using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Common.CQRS;
using Domain.Dto.Quez;
using Domain.Entities.Quez;
using Dto.Quez;
using infrastructure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Shared.OperationResult;

namespace Teacher.Quez.Query.Get;

public class GetQuezDetailHandler : OperationResult, IQueryHandler<GetQuezDetailQuery>
{

    private ApplicationDbContext _context;
    public GetQuezDetailHandler(ApplicationDbContext context){

        _context=context;

    }
    public async Task<JsonResult> Handle(GetQuezDetailQuery request, CancellationToken cancellationToken)
    {

     
        var StudentsAnswers=_context
        .Quezs
        .AsNoTracking()
        .Where(x=>x.Id==request.Id)
        .Select(x=>new GetFinishQuezDetailDto{

            Id=x.Id,
            Name=x.Name,
            StartAt=x.StartAt,
            EndAt=x.EndAt,
            Students=x.StudentQuezs.Select(y=>new GetFinishQuezDetailDto.Student{

                Id=y.StudentId,
                Name=y.Student.Name,
                Image=y.Student.Image,
                Hash=y.Student.Hash,
                Precent=(y.StudentAnswers.Where(x=>x.Answer.IsCorrect).Sum(x=>x.Answer.Question.Score)/x.Questions.Sum(x=>x.Score))

            }).ToList()


        })
        .First();

        return Success(StudentsAnswers,"this is student with quez info");



    }
}
