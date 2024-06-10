using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Common.CQRS;
using Domain.Dto.Student;
using infrastructure;
using Microsoft.AspNetCore.Mvc;
using Shared.OperationResult;

namespace Admin.Student.Parent.Query.GetStudent;

public class GetAllParentStudentHandler : OperationResult ,IQueryHandler<GetAllParentStudentQuery>
{

    private ApplicationDbContext _context;
    public GetAllParentStudentHandler(ApplicationDbContext context){

        _context=context;

    }
    public async Task<JsonResult> Handle(GetAllParentStudentQuery request, CancellationToken cancellationToken)
    {

        var Students=_context
        .Students
        .Where(x=>x.ParentId==request.Id)
        .Select(x=>new GetAllStudentParentDto{

            Id=x.Id,
            Name=x.Name,
            Image=x.Image,
            Hash=x.Hash,
            Email=x.Email
            
        })
        .ToList();


        return Success(Students,"this is all students");
    }
}
