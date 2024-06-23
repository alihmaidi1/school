using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Common.CQRS;
using Domain.Dto.Student;
using infrastructure;
using Microsoft.AspNetCore.Mvc;
using Shared.OperationResult;
using Shared.Services.User;

namespace Parent.Student.Query.GetAllName;
public class GetAllChildNameHandler : OperationResult,IQueryHandler<GetAllChildNameQuery>
{

    private ApplicationDbContext _context;

    private ICurrentUserService _currentUserService;
    public GetAllChildNameHandler(ApplicationDbContext context,ICurrentUserService currentUserService){

        _context=context;
        _currentUserService=currentUserService;

    }
    public async Task<JsonResult> Handle(GetAllChildNameQuery request, CancellationToken cancellationToken)
    {

        var Students=_context
        .Students
        .Where(x=>x.ParentId==_currentUserService.GetUserid())
        .Select(x=>new GetAllStudentNameDto{

            Id=x.Id,
            Name=x.Name,
            Image=x.Image,
            Hash=x.Hash
        })
        .ToList();

        return Success(Students,"this is all student name");
    }
}
