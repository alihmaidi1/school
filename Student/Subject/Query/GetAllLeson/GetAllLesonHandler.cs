using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Common.CQRS;
using Domain.Dto.Student;
using infrastructure;
using Microsoft.AspNetCore.Mvc;
using Shared.Entity.EntityOperation;
using Shared.OperationResult;

namespace Student.Subject.Query.GetAllLeson;

public class GetAllLesonHandler : OperationResult,IQueryHandler<GetAllLesonQuery>
{

    private ApplicationDbContext _context;
    public GetAllLesonHandler(ApplicationDbContext context){

        _context=context;
    }
    public async Task<JsonResult> Handle(GetAllLesonQuery request, CancellationToken cancellationToken)
    {

        var Result=new GetAllStudentLesonDto();
        Result.StudentCount=_context
        .SubjectYears
        .Where(x=>x.Id==request.SubjectYearId)
        .SelectMany(x=>x.StudentSubjects)
        .Count();

        Result.QuezCount=_context
        .SubjectYears
        .Where(x=>x.Id==request.SubjectYearId)
        .SelectMany(x=>x.Quezs)
        .Count();

        Result.LesonCount=_context
        .SubjectYears
        .Where(x=>x.Id==request.SubjectYearId)
        .SelectMany(x=>x.Lesons)
        .Count();

        Result.Lesons=_context
        .SubjectYears
        .Where(x=>x.Id==request.SubjectYearId)
        .SelectMany(x=>x.Lesons)
        .Where(x=>x.Name.Contains(request.Search??""))
        .Select(x=>new GetAllStudentLesonDto.Leson{

            Id=x.Id,
            Name=x.Name,
            Url=x.Url

        }).ToList();

        return Success(Result);


    }
}
