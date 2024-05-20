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

namespace Admin.ClassRoom.Student.Query.GetByStage;
public class GetStudentByStageHandler : OperationResult,IQueryHandler<GetStudentByStageQuery>
{

    private ApplicationDbContext _context;

    public GetStudentByStageHandler(ApplicationDbContext context){

        _context=context;
    }
    public async Task<JsonResult> Handle(GetStudentByStageQuery request, CancellationToken cancellationToken)
    {

        return null;
        // var Students=_context
        // .Classes
        // .Where(x=>x.StageId==request.Id)
        
        // .SelectMany(x=>x.Subjects)
        // .SelectMany(x=>x.SubjectYears.Where(y=>y.Year.Date.Year==DateTime.Now.Year))
        // .SelectMany(x=>x.StudentSubjects)
        // .Select(x=>x.Student)
        // .Select(x=>new GetAllStudentStageDto{

        //     Id=x.Id,
        //     Name=x.Name,
        //     Email=x.Email,
        //     Image=x.Image,
        //     Hash=x.Hash
        // })
        // .ToPagedList(request.PageNumber,request.PageSize);
   
        // return Success(Students,"this is all student");
    }


}
