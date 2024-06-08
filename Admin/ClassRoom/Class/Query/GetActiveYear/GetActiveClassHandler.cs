using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Common.CQRS;
using Domain.Dto.ClassRoom;
using infrastructure;
using Microsoft.AspNetCore.Mvc;
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
        .ClassYears
        .Where(x=>x.Status)
        .Select(x=>new GetAllActiveClassDto{

            Id=x.Id,
            Name=x.Class.Name,
            Date=x.Year.Date
        })
        .ToList();

        return Success(Classes,"this is all active class");
    }
}
