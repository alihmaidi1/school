using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Shared.CQRS;

namespace Teacher.Leson.Command.Delete;

public class DeleteLesonCommand: ICommand
{

    public Guid Id{get;set;}

}
