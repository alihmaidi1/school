using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Shared.CQRS;

namespace Teacher.Quez.Command.Delete;

public class DeleteQuezCommand:ICommand
{

    public Guid Id{get;set;}

}
