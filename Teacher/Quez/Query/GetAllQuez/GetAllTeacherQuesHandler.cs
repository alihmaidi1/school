using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Common.CQRS;
using Dto.Admin.Teacher;
using infrastructure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Shared.CQRS;
using Shared.Entity.EntityOperation;
using Shared.OperationResult;
using Shared.Services.User;

namespace Teacher.Quez.Query.GetAllQuez;

public class GetAllTeacherQuesHandler : OperationResult, IQueryHandler<GetAllQuezQuery>
{

    private readonly ApplicationDbContext _context;
    private ICurrentUserService _currentUserService;
    public GetAllTeacherQuesHandler(ApplicationDbContext context,ICurrentUserService currentUserService){

        _currentUserService=currentUserService;
        _context=context;


    }
    public async Task<JsonResult> Handle(GetAllQuezQuery request, CancellationToken cancellationToken)
    {

        var Result=_context
        .SubjectYears
        .Where(x=>x.TeacherId==_currentUserService.GetUserid())
        .Where(x=>x.ClassYear.YearId==request.YearId)
        .Select(x=>new GetAllTeacherQuezDto(){

            Id=x.Subject.Id,
            Name=x.Subject.Name,            
            Quezies=x.Quezs.Select(y=>new GetAllTeacherQuezDto.Quez(){

                Id=y.Id,
                Name=y.Name,
                StartAt=y.StartAt,
                EndAt=y.EndAt,
                QuestionNumber=y.Questions.Count(),
                Student=y.StudentQuezs.Count()

            }).GroupBy(x=>x.Id).Select(x=>x.First()).ToList()            

        })
        .ToPagedList(request.PageNumber,request.PageSize);
        return Success(Result,"this is all your data");


    }
}
