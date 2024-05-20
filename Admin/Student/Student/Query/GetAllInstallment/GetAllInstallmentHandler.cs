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

        // var Installments=_context
        // .SubjectYears
        // .AsNoTracking()
        // .Select(x=>new GetAllInstallmentDto{

        //     Id=x.Subject.ClassId,
        //     Name=x.Subject.Class.Name,
        //     Year=x.Year.Date.Year.ToString(),
        //     Mark=(x.StudentSubjects
        //     .Where(x=>x.StudentId==request.Id)
        //     .Sum(x=>x.Mark??0)/x.StudentSubjects
        //     .Where(x=>x.StudentId==request.Id)
        //     .Count())
        // })
        // .ToList();

        // return Success(Installments,"this is all installment");

        return null;
    }
}
