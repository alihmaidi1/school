using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Common.CQRS;
using Domain.Dto.ClassRoom;
using infrastructure;
using Microsoft.AspNetCore.Mvc;
using Shared.OperationResult;

namespace Admin.ClassRoom.Year.Query.GetAll;

public class GetAllYearHandler : OperationResult, IQueryHandler<GetAllYearQuery>
{

    private ApplicationDbContext _context;
    public GetAllYearHandler(ApplicationDbContext context){

        _context=context;

    }
    public async Task<JsonResult> Handle(GetAllYearQuery request, CancellationToken cancellationToken)
    {
        
        var Years=_context.Years.Select(x=>new GetAllYearDto{

            Id=x.Id,
            Name=x.Date.ToString()
        }).ToList();

        return Success(Years,"this is all year");
    
    }
}
