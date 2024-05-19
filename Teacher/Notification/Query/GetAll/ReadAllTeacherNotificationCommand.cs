using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Shared.Abstraction;
using Shared.CQRS;

namespace Teacher.Notification.Query.GetAll;

public class ReadAllTeacherNotificationCommand: PaginationRequest, ICommand
{

    

}
