using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Shared.CQRS;

namespace Admin.ClassRoom.Class.Command.FinishYear;

public class FinishYearCommand: ICommand
{

    public Guid ClassId{get;set;}

}
