using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Shared.CQRS;

namespace Parent.Student.Command.GiveReasonOfAudience;

public class GiveReasonOfAudienceCommand: ICommand
{

    public Guid Id{get;set;}

    public string Reason{get;set;}

}
