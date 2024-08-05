using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Common.CQRS;
using Domain.Dto.Student;
using infrastructure;
using Microsoft.AspNetCore.Mvc;
using Shared.OperationResult;

namespace Admin.Parent.GetAllParentOrStudent;

public class GetAllParentOrStudentHandler : OperationResult,IQueryHandler<GetAllParentOrStudentQuery>
{

    private ApplicationDbContext _context;
    public GetAllParentOrStudentHandler(ApplicationDbContext context){


        _context=context;
    }
    public async Task<JsonResult> Handle(GetAllParentOrStudentQuery request, CancellationToken cancellationToken)
    {

        List<GetAllStudentOrParentDto> All=new List<GetAllStudentOrParentDto>();

        if(request.Status){

            All.AddRange(_context.Parents.Select(x=>new GetAllStudentOrParentDto{

                Id=x.Id,
                Name=x.Name

            }).ToList());

        }else{


            All.AddRange(_context.Students.Select(x=>new GetAllStudentOrParentDto{

                Id=x.Id,
                Name=x.Name

            }).ToList());


        }

            return Success(All,"this is all student and parent");


    }
}
