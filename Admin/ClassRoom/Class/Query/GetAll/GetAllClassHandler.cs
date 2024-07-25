using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using Common.CQRS;
using Domain.Dto.ClassRoom;
using infrastructure;
using Microsoft.AspNetCore.Mvc;
using Shared.OperationResult;

namespace Admin.ClassRoom.Class.Query.GetAll;

public class GetAllClassHandler : OperationResult,IQueryHandler<GetAllClassQuery>
{

    private ApplicationDbContext _context;

    public GetAllClassHandler(ApplicationDbContext context){


        _context=context;

    }     
    public async Task<JsonResult> Handle(GetAllClassQuery request, CancellationToken cancellationToken)
    {

        var Classes=_context
        .Classes
        .AsNoTracking()
        .Select(x=>new GetAllClassDto{

            Id=x.Id,
            Name=x.Name
        })
        .ToList();

        return Success(Classes);
    }
}
