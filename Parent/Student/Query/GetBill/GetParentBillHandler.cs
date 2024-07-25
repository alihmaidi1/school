using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Common.CQRS;
using Domain.Dto.Parent;
using infrastructure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Shared.Entity.EntityOperation;
using Shared.OperationResult;
using Shared.Services.User;

namespace Parent.Student.Query.GetBill;

public class GetParentBillHandler : OperationResult,IQueryHandler<GetParentBillQuery>
{


    private ApplicationDbContext _context;
    private ICurrentUserService _currentUserService;
    public GetParentBillHandler(ApplicationDbContext context,ICurrentUserService currentUserService){


        _context=context;
        _currentUserService=currentUserService;

    }
    public async Task<JsonResult> Handle(GetParentBillQuery request, CancellationToken cancellationToken)
    {

        var StudentBills=_context
        .Students
        .AsNoTracking()
        .AsSplitQuery()
        .Where(x=>x.ParentId==_currentUserService.GetUserid())
        .Where(x=>x.Id==request.StudentId)
        .Select(x=>new GetAllParentBillDto{

            Id=x.Id,
            Name=x.Name,
            Bills=x
            .StudentBills
            .Where(x=>x.Bill.ClassYear.Status)
            .Where(x=>x.Money-x.PaiedMoney>0)
            .Select(y=>new GetAllParentBillDto.Bill{

                Date=y.Bill.Date,
                ClassName=y.Bill.ClassYear.Class.Name,
                Money=y.Money-y.PaiedMoney

            }).ToList()

        })
        .First();

        return Success(StudentBills,"this is all student bill");
     
     
    }
}
