using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using infrastructure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Shared.CQRS;
using Shared.OperationResult;

namespace Admin.Student.Student.Command.PayBill;

public class PayBillHandler : OperationResult,ICommandHandler<PayBillCommand>
{

    private ApplicationDbContext _context;

    public PayBillHandler(ApplicationDbContext context){

        _context=context;
    }
    public async Task<JsonResult> Handle(PayBillCommand request, CancellationToken cancellationToken)
    {

        await _context
        .StudentBills
        .Where(x=>x.Id==request.Id)
        .ExecuteUpdateAsync(setter=>setter.SetProperty(x=>x.PaiedMoney,x=>x.Money),cancellationToken);
        return Success("payed successfully");
    }
}
