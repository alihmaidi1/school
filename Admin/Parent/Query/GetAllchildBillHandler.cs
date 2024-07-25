
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

namespace Admin.Parent.Query;

public class GetAllchildBillHandler : OperationResult,IQueryHandler<GetAllChildBillQuery>
{

    private ApplicationDbContext _context;
    public GetAllchildBillHandler(ApplicationDbContext context){

        _context=context;


    }
    public async Task<JsonResult> Handle(GetAllChildBillQuery request, CancellationToken cancellationToken)
    {

        var GetStudentBills=_context
        .StudentBills
        .AsNoTracking()
        .Where(x=>x.Student.ParentId==request.ParentId)        
        .Where(x=>(x.Money-x.PaiedMoney)>0)
        .Select(x=>new GetAllStudentBillDto{
            StudentId=x.StudentId,
            StudentName=x.Student.Name,
            BillId=x.BillId,
            Money=x.Money
        })
        .ToList();
        return Success(GetStudentBills);
    }
}
