using Common.CQRS;
using Domain.Dto.ClassRoom;
using infrastructure;
using Microsoft.AspNetCore.Mvc;
using Shared.Entity.EntityOperation;
using Shared.OperationResult;

namespace Admin.ClassRoom.Class.Query.GetAllBill;

public class GetAllBillHandler : OperationResult,IQueryHandler<GetAllBillQuery>
{

    private ApplicationDbContext _context;
    public GetAllBillHandler(ApplicationDbContext context){

        _context=context;
    }
    public async Task<JsonResult> Handle(GetAllBillQuery request, CancellationToken cancellationToken)
    {
        var StudentBill=_context
        .ClassYears
        .Where(x=>x.ClassId==request.ClassId)
        .Where(x=>x.YearId==request.YearId)
        .SelectMany(x=>x.Bills)
        .SelectMany(x=>x.StudentBills)
        .GroupBy(x=>x.Student)
        .Select(x=>new GetAllClassBillDto{

            Id=x.Key.Id,
            Name=x.Key.Name,
            Recived=x.Count(x=>x.PaiedMoney==x.Money),
            Remaining=x.Count(x=>x.PaiedMoney!=x.Money),
            Total=x.Sum(x=>x.PaiedMoney),
            Status=x.All(x=>x.PaiedMoney==x.Money)
            
        })
        .ToPagedList(request.PageNumber,request.PageSize);
        return Success(StudentBill,"this is all bills");
    
    }
}
