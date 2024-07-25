using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Common.CQRS;
using Domain.Dto.Teacher;
using infrastructure;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Shared.Entity.EntityOperation;
using Shared.OperationResult;

namespace Admin.Teacher.VacationType.Query.GetAll;

public class GetAllVacationTypeHandler : OperationResult,IQueryHandler<GetAllVacationTypeQuery>
{

    private ApplicationDbContext _context;
    public GetAllVacationTypeHandler(ApplicationDbContext context){

        _context=context;
    }
    public async Task<JsonResult> Handle(GetAllVacationTypeQuery request, CancellationToken cancellationToken)
    {

        var vacationsType=_context
        .VacationTypes
        .AsNoTracking()
        .Select(x=>new GetAllVacationTypeDto{

            Id=x.Id,
            Name=x.Name
        })
        .ToPagedList(request.PageNumber,100);

        return Success(vacationsType,"this is all data");
    }
}
