using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Common.CQRS;
using Domain.Dto.Student;
using infrastructure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Shared.Entity.EntityOperation;
using Shared.OperationResult;
using Shared.Services.User;

namespace Student.Subject.Query.GetAllQuez;

public class GetAllQuezHandler : OperationResult,IQueryHandler<GetAllQuezQuery>
{

    private ApplicationDbContext _context;
    private ICurrentUserService _currentUserService;
    public GetAllQuezHandler(ApplicationDbContext context,ICurrentUserService currentUserService){

        _context=context;
        _currentUserService=currentUserService;

    }
    public async Task<JsonResult> Handle(GetAllQuezQuery request, CancellationToken cancellationToken)
    {
        var Result=new GetAllStudentQuezDto();
        Result.StudentCount=_context
        .SubjectYears    
        .AsNoTracking()
        .Where(x=>x.Id==request.SubjectYearId)
        .SelectMany(x=>x.StudentSubjects)
        .Count();

        Result.QuezCount=_context
        .SubjectYears
        .AsNoTracking()
        .Where(x=>x.Id==request.SubjectYearId)
        .SelectMany(x=>x.Quezs)
        .Count();

        Result.LesonCount=_context
        .SubjectYears
        .AsNoTracking()
        .Where(x=>x.Id==request.SubjectYearId)
        .SelectMany(x=>x.Lesons)
        .Count();

        Result.Quezs=_context
        .Students
        .AsNoTracking()
        .Where(x=>x.Id==_currentUserService.UserId)
        .SelectMany(x=>x.StudentQuezs.Where(x=>x.Quez.SubjectYearId==request.SubjectYearId))
        .Select(x=>new GetAllStudentQuezDto.Quez{

            Id=x.Id,
            StartAt=x.Quez.StartAt,
            Name=x.Quez.Name,
            QuestionNumber=x.Quez.Questions.Count()
        })        
        .ToPagedList(request.PageNumber,request.PageSize);


        return Success(Result); 
    }
}
