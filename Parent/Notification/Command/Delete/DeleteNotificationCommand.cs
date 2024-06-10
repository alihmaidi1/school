using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Shared.CQRS;

namespace Parent.Notification.Command.Delete;

public class DeleteNotificationCommand: ICommand
{

    public Guid Id{get;set;}

}
