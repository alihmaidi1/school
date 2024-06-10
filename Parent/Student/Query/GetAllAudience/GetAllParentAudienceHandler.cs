using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Common.CQRS;
using Domain.Dto.Parent;
using infrastructure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Shared.Entity.EntityOperation;
using Shared.OperationResult;
using Shared.Services.User;

namespace Parent.Student.Query.GetAllAudience;

public class GetAllParentAudienceHandler : OperationResult,IQueryHandler<GetAllParentAudienceQuery>
{

    private ApplicationDbContext _context;

    private ICurrentUserService _currentUserService;
    public GetAllParentAudienceHandler(ApplicationDbContext context,ICurrentUserService currentUserService){

        _context=context;
        _currentUserService=currentUserService;
    }
    public async Task<JsonResult> Handle(GetAllParentAudienceQuery request, CancellationToken cancellationToken)
    {

        var ChildsFilter=request.Childs?.Any()??false;
        var Audiences=_context
        .Students
        .AsNoTracking()
        .AsSplitQuery()
        .Where(x=>x.ParentId==_currentUserService.UserId)
        .Where(x=>ChildsFilter?request.Childs!.Contains(x.Id):true)
        .Select(x=>new GetAllParentStudentAudienceDto{

            Id=x.Id,
            Name=x.Name,
            Audiences=x
            .Audiences
            .Where(x=>x.SubjectYear.ClassYear.Status)
            .Where(x=>!x.IsExists&&x.Reason==null)
            .Select(y=>new GetAllParentStudentAudienceDto.Audience{
                Id=y.Id,
                Date=y.Date,
                SessionNumber=y.SessionNumber,
                SubjectName=y.SubjectYear.TeacherSubject.Subject.Name
            }).ToList()
            
        })
        .ToPagedList(request.PageNumber,request.PageSize);
        return Success(Audiences);
    }
}
