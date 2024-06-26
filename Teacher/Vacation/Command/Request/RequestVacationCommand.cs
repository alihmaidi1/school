using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Enum.Ordering;
using Shared.CQRS;

namespace Teacher.Vacation.Command.Request;

public class RequestVacationCommand: ICommand
{

    public string Reason{get;set;}

    public DateTimeOffset StartAt{get;set;}

    public Guid TypeId{get;set;}

    public int Period{get;set;}

}
