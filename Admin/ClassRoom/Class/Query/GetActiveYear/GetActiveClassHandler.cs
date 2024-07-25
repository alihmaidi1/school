using System;
using System.Collections.Generic;
// using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using Common.CQRS;
using Domain.Dto.ClassRoom;
using infrastructure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Shared.OperationResult;

namespace Admin.ClassRoom.Class.Query.GetActiveYear;

public class GetActiveClassHandler : OperationResult,IQueryHandler<GetActiveClassQuery>
{


    private ApplicationDbContext _context;
    public GetActiveClassHandler(ApplicationDbContext context){


        _context=context;

    }
    public async Task<JsonResult> Handle(GetActiveClassQuery request, CancellationToken cancellationToken)
    {


        var Classes=_context
        .Classes
        .AsNoTracking()
        .Where(x=>x.ClassYears.Any(x=>x.Status)||!x.ClassYears.Any(x=>!x.Status&&x.Year.Date.Year==DateTime.UtcNow.Year))           
        .Select(x=>new GetAllActiveClassDto{

            Id=x.Id,            
            Status=x.ClassYears.Any(x=>x.Status),
            Name=x.Name,            
        })        
        .ToList();

        return Success(Classes,"this is all active class");
    }
}
