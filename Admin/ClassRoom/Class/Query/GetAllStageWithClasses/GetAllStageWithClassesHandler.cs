using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Common.CQRS;
using Domain.Dto.ClassRoom;
using infrastructure;
using Microsoft.AspNetCore.Mvc;
using Shared.OperationResult;

namespace Admin.ClassRoom.Class.Query.GetAllStageWithClasses;

public class GetAllStageWithClassesHandler : OperationResult,IQueryHandler<GetAllStageWithClassesQuery>
{

    private ApplicationDbContext _context;
    public GetAllStageWithClassesHandler(ApplicationDbContext context){

        _context=context;
    }
    public async Task<JsonResult> Handle(GetAllStageWithClassesQuery request, CancellationToken cancellationToken)
    {

        var Stages=_context
        .Stages
        .Select(x=>new GetAllStageAndClassesDto{

            Id=x.Id,
            Name=x.Name,
            Class=x.Classes.Select(y=>new GetAllStageAndClassesDto.Classes{

                Id=y.Id,
                Name=y.Name

            }).ToList()

        })
        .ToList();
        
        
        return Success(Stages,"this is your data");
    }
}
