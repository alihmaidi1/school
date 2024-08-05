using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Enum;
using Shared.CQRS;

namespace Admin.Notification.Command.Send;

public class SendNotificationCommand: ICommand
{


    public string Title{get;set;}

    public string Body{get;set;}

    public List<Guid> Ids{get;set;}

}
