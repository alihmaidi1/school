using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using Common.CQRS;
using Domain.Dto.Session;
using infrastructure;
using Microsoft.AspNetCore.Mvc;
using Shared.Entity.EntityOperation;
using Shared.OperationResult;
using Shared.Services.User;

namespace Admin.ClassRoom.Subject.Query.GetSession;

public class GetSessionHandler : OperationResult,IQueryHandler<GetSessionQuery>
{

    private ApplicationDbContext _context;
    private ICurrentUserService _currentUserService;
    public GetSessionHandler(ApplicationDbContext context,ICurrentUserService currentUserService){

        _context=context;
        _currentUserService=currentUserService;

    }

    public async Task<JsonResult> Handle(GetSessionQuery request, CancellationToken cancellationToken)
    {

        var SessionNumber=_context
        .SubjectYears
        .AsNoTracking()
        .Where(x=>x.SubjectId==request.SubjectId);
        if(request.YearId.HasValue){

            SessionNumber=SessionNumber.Where(x=>x.ClassYear.YearId==request.YearId);

        }else{

            SessionNumber=SessionNumber.Where(x=>x.ClassYear.Status);
        }

        if(!_currentUserService.IsAdmin()){

            SessionNumber=SessionNumber.Where(x=>x.TeacherId==_currentUserService.GetUserid());
        }

        var Result=SessionNumber
        .Select(x=>new GetSessionWithExistsStudentDto{

            Status=x.ClassYear.Status,
            Sessions=x.Audiences.GroupBy(x=>x.SessionNumber).Select(y=>new GetSessionWithExistsStudentDto.Session{

                SessionNumber=y.Key,
                ExistsCount=y.Count(z=>z.IsExists),
                Students=y.Select(y=>new GetSessionWithExistsStudentDto.Session.Student{
                Id=y.Student.Id,
                Name=y.Student.Name,
                Status=y.IsExists
            }).ToList()

            }).ToPagedList(request.PageNumber,request.PageSize)

        })
        .FirstOrDefault();

        return Success(Result,"this is your session number");
    }
}
