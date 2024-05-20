using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Common.CQRS;
using Domain.Dto.ClassRoom;
using infrastructure;
using Microsoft.AspNetCore.Mvc;
using Shared.Entity.EntityOperation;
using Shared.OperationResult;

namespace Admin.ClassRoom.Class.Query;

public class GetFinalResultHandler : OperationResult ,IQueryHandler<GetFinalResultQuery>
{

    private ApplicationDbContext _context;

    public GetFinalResultHandler(ApplicationDbContext context){

        _context=context;
 
    }
    public async Task<JsonResult> Handle(GetFinalResultQuery request, CancellationToken cancellationToken)
    {

        var Result=_context
        .SubjectYears
        .SelectMany(x=>x.StudentSubjects)
        .GroupBy(x=>x.Student)
        .Select(x=>new GetAllResultDto{

            Id=x.Key.Id,
            Name=x.Key.Name,
            Status=x.Count(x=>x.Mark>50)>2,
            Precent=x.Sum(x=>(float)x.Mark)/x.Count()            

            

            
        })
        .ToPagedList(request.PageNumber,request.PageSize);

        return Success(Result,"this is the result");
    }
}
