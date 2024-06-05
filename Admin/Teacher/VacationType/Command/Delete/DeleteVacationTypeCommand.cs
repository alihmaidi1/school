using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Shared.CQRS;

namespace Admin.Teacher.VacationType.Command.Delete;

public class DeleteVacationTypeCommand: ICommand
{

    public Guid Id{get;set;}
    

}
