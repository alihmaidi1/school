using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Common.CQRS;
using Domain.Dto.Quez;
using infrastructure;
using Microsoft.AspNetCore.Mvc;
using Org.BouncyCastle.Asn1.Misc;
using Shared.Entity.EntityOperation;
using Shared.OperationResult;

namespace Teacher.Quez.Query.GetAll;

public class GetAllTeacherQuezHandler : OperationResult, IQueryHandler<GetAllTeacherQuezQuery>
{

    private ApplicationDbContext _context;
    public GetAllTeacherQuezHandler(ApplicationDbContext context){

        _context=context;

    }
    public async Task<JsonResult> Handle(GetAllTeacherQuezQuery request, CancellationToken cancellationToken)
    {

        // var Quezes=_context
        // .SubjectYears
        // .Where(x=>x.YearId==request.YearId)
        // .SelectMany(x=>x.StudentSubjects)
        // .SelectMany(x=>x.StudentQuezs)    
        // .Select(x=>x.Quez)    
        // .Distinct()
        // .Select(x=>new GetAllQuezTeacherDto{

        //     Id=x.Id,
        //     Name=x.Name,
        //     StartAt=x.StartAt.ToString()
        // })        
        // .ToPagedList(request.PageNumber,request.PageSize);
        // return Success(Quezes,"this is all quezes");

        return null;
    }
}
