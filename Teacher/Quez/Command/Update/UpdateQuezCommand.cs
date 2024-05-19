using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Shared.CQRS;

namespace Teacher.Quez.Command.Update;

public class UpdateQuezCommand: ICommand
{

    public Guid Id{get;set;}

    public string Name{get;set;}

    public DateTime StartAt{get;set;}


}
