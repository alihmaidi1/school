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
        .Where(x=>x.Id==request.Id)
        .Select(x=>new GetFinishQuezDetailDto{

            Id=x.Id,
            Name=x.Name,
            StartAt=x.StartAt.ToString(),
            Students=x.StudentQuezs.Select(y=>new GetFinishQuezDetailDto.Student{

                Id=y.StudentSubject.StudentId,
                Name=y.StudentSubject.Student.Name,
                Image=y.StudentSubject.Student.Image,
                Hash=y.StudentSubject.Student.Hash,
                Precent=(y.StudentAnswers.Count(x=>x.Answer.IsCorrect)/x.Questions.Count())

            }).ToList()


        })
        .First();

        return Success(StudentsAnswers,"this is student with quez info");



    }
}
