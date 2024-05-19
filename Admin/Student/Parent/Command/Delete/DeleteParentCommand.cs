using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Shared.CQRS;

namespace Admin.Student.Parent.Command.Delete;
public class DeleteParentCommand: ICommand
{

    public Guid Id{get;set;}

}
