using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Common.CQRS;
using Shared.Abstraction;

namespace Parent.Notification.Query.GetAll;

public class GetAllNotificationQuery: PaginationRequest,IQuery
{

}
