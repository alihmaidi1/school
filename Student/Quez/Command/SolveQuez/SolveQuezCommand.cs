using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Shared.CQRS;

namespace Student.Quez.Command.SolveQuez;

public class SolveQuezCommand: ICommand
{

    public Guid Id{get;set;}

    public List<Guid> Answers{get;set;}

    

}
