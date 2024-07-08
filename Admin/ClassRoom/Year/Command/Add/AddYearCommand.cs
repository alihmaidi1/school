using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Shared.CQRS;

namespace Admin.ClassRoom.Year.Command.Add;

public class AddYearCommand: ICommand
{

    public DateTime Datetime{get;set;}

    

}
