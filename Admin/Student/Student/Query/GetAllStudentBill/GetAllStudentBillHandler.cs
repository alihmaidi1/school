using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Common.CQRS;
using Domain.Dto.Student;
using infrastructure;
using Microsoft.AspNetCore.Mvc;
using Shared.OperationResult;

namespace Admin.Student.Student.Query.GetAllStudentBill;

public class GetAllStudentBillHandler : OperationResult,IQueryHandler<GetAllStudentBillQuery>
{

    private ApplicationDbContext _context;

    public GetAllStudentBillHandler(ApplicationDbContext context){

        _context=context;

    }
    public async Task<JsonResult> Handle(GetAllStudentBillQuery request, CancellationToken cancellationToken)
    {

        var Bills=_context
        .StudentBills
        .Where(x=>x.StudentId==request.StudentId)
        .Where(x=>x.Bill.ClassYear.YearId==request.YearId)
        .Where(x=>x.Bill.ClassYear.ClassId==request.ClassId)
        .Where(x=>x.PaiedMoney<x.Money)
        .GroupBy(x=>x.StudentId)
        
        .Select(x=>new GetAllStudentBillDto{

            Sum=x.Select(y=>y.Money-y.PaiedMoney).Sum(),
            StudentBills=x.Select(y=>new GetAllStudentBillDto.StudentBill{

                Id=y.Id,
                Money=y.Money-y.PaiedMoney,
                


            }).ToList()
        })
        .FirstOrDefault();
        return Success(Bills,"this is bill info");
    }
}
