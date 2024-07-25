using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Common.CQRS;
using Domain.Dto.Student;
using infrastructure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Shared.OperationResult;
using Shared.Services.User;

namespace Student.Quez.Query.GetAll;

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
        var Result=_context
        .Students
        .AsNoTracking()
        .Where(x=>x.Id==_currentUserService.GetUserid())
        .SelectMany(x=>x.StudentQuezs)
        .Where(x=>x.Quez.StartAt<=DateTime.UtcNow&&x.Quez.EndAt>DateTime.UtcNow)
        .Where(x=>!x.StudentAnswers.Any())
        .Select(x=>new GetAllStudentQuezDto.Quez{

            Id=x.Id,
            StartAt=x.Quez.StartAt,
            EndAt=x.Quez.EndAt,
            Name=x.Quez.Name,
            QuestionNumber=x.Quez.Questions.Count()
        })        
        .ToList();

        return Success(Result);
    }
}
