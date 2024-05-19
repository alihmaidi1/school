using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Common.CQRS;
using Domain.Dto.Student;
using infrastructure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Shared.OperationResult;

namespace Admin.Student.Student.Query.GetAllInstallment;

public class GetAllInstallmentHandler : OperationResult ,IQueryHandler<GetAllInstallmentQuery>
{

    private ApplicationDbContext _context;
    public GetAllInstallmentHandler(ApplicationDbContext context){


        _context=context;
    }
    public async Task<JsonResult> Handle(GetAllInstallmentQuery request, CancellationToken cancellationToken)
    {

        var Installments=_context
        .Classes
        .AsNoTracking()
        .Select(x=>new GetAllInstallmentDto{

            // Id=x.Id,
            // Name=x.Name,
            // Year=x.SubjectYear.Year.Date.Year.ToString(),
            
            

        })
        .ToList();

        return Success(Installments,"this is all installment");
    }
}
