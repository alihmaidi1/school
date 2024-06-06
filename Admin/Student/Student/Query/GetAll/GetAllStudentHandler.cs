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

namespace Admin.Student.Student.Query.GetAll;

public class GetAllStudentHandler : OperationResult,IQueryHandler<GetAllStudentQuery>
{

    private ApplicationDbContext _context;
    public GetAllStudentHandler(ApplicationDbContext context){

        _context=context;
    }
    public async Task<JsonResult> Handle(GetAllStudentQuery request, CancellationToken cancellationToken)
    {

        var Students=_context
        .Students
        .Select(x=>new GetAllStudentStageDto{

            Id=x.Id,
            Name=x.Name,
            Image=x.Image,
            Hash=x.Hash,
            Email=x.Email
        })
        .ToPagedList(request.PageNumber,request.PageSize);

        return Success(Students);
    }
}
