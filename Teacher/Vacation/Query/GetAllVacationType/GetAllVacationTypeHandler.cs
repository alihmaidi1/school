using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Common.CQRS;
using Domain.Dto.Teacher;
using infrastructure;
using Microsoft.AspNetCore.Mvc;
using Shared.OperationResult;

namespace Teacher.Vacation.Query.GetAllVacationType;

public class GetAllVacationTypeHandler :OperationResult , IQueryHandler<GetAllVacationTypeQuery>
{

    private ApplicationDbContext _context;
    public  GetAllVacationTypeHandler(ApplicationDbContext context){

        _context=context;
    }


    public async Task<JsonResult> Handle(GetAllVacationTypeQuery request, CancellationToken cancellationToken)
    {

        var VactionsTypes=_context
        .VacationTypes
        .Select(x=>new GetAllVacationTypeDto{

            Id=x.Id,
            Name=x.Name
        })
        .ToList();


        return Success(VactionsTypes,"this is all data");

    }
}
