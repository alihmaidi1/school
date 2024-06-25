using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Shared.CQRS;

namespace Teacher.Quez.Command.Add;

public class AddQuezCommand: ICommand
{

    public string Name{get;set;}

    public DateTimeOffset StartAt{get;set;}

    public DateTimeOffset EndAt{get;set;}

    public Guid SubjectId{get;set;}


}
