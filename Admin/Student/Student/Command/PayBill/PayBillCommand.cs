using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Shared.CQRS;

namespace Admin.Student.Student.Command.PayBill;

public class PayBillCommand: ICommand
{

    public Guid Id{get;set;}

}
