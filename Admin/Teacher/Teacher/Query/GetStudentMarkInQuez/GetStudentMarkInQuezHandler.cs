using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Common.CQRS;
using Dto.Quez;
using infrastructure;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Shared.OperationResult;

namespace Admin.Teacher.Teacher.Query.GetStudentMarkInQuez;

public class GetStudentMarkInQuezHandler :OperationResult ,IQueryHandler<GetStudentMarkInQuezQuery>
{

    private ApplicationDbContext _context;

    public GetStudentMarkInQuezHandler(ApplicationDbContext context){

        _context=context;
    }
    public async Task<JsonResult> Handle(GetStudentMarkInQuezQuery request, CancellationToken cancellationToken)
    {
        var StudentsAnswers=_context
        .Quezs
        .AsNoTracking()
        .AsSplitQuery()
        .Where(x=>x.Id==request.Id)
        .Where(x=>x.EndAt>=DateTimeOffset.UtcNow)

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

        return Success(StudentsAnswers,"this is your data");


    }
}
