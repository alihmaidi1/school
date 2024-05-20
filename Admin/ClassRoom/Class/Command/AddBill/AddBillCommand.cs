using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Shared.CQRS;

namespace Admin.ClassRoom.Class.Command.AddBill;

public class AddBillCommand: ICommand
{

    public Guid Id{get;set;}

    public float Money{get;set;}

    public DateTime Date{get;set;}

}
