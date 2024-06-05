using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Shared.CQRS;

namespace Admin.Teacher.VacationType.Command.Add;

public class AddVacationTypeCommand:ICommand
{

    public string Name{get;set;}

}
