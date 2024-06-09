using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Common.CQRS;
using Domain.Dto.ClassRoom;
using infrastructure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Shared.OperationResult;

namespace Admin.ClassRoom.Class.Query.GetUnActiveYear;

public class GetUnActiveYearHandler : OperationResult,IQueryHandler<GetUnActiveClassQuery>
{

    private ApplicationDbContext _context;
    public GetUnActiveYearHandler(ApplicationDbContext context){

        _context=context;

    }
    public async Task<JsonResult> Handle(GetUnActiveClassQuery request, CancellationToken cancellationToken)
    {

        var Classes=_context
        .Classes
        .AsNoTracking()
        .Where(x=>!x.ClassYears.Any(x=>x.Status))
        .Select(x=>new GetUnActiveClassDto{

            Id=x.Id,
            Name=x.Name,
        })
        .ToList();

        return Success(Classes,"this is all active class");
    
    }
}
