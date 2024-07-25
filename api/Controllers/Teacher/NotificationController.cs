using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Dto.Notification;
using infrastructure.Attribute;
using Microsoft.AspNetCore.Mvc;
using schoolManagement.Base;
using Shared.Entity.EntityOperation;
using Shared.Enum;
using Shared.OperationResult.Base;
using Shared.Swagger;
using Teacher.Notification.Query.GetAll;

namespace schoolmanagment.Controllers.Teacher;


[ApiGroup(ApiGroupName.All, ApiGroupName.Teacher)]
[Microsoft.AspNetCore.Mvc.Route("Api/Teacher/[controller]/[action]")]
[CheckTokenSession(AuthenticationSchemes =nameof(JwtSchema.Teacher))]
public class NotificationController: ApiController
{


        /// <summary>
    /// Create a new question to specific quez in currect year
    /// </summary>
    [Produces(typeof(OperationResultBase<PageList<GetAllNotificationDto>>))]
    [HttpGet]
    public async Task<IActionResult> ReadAll([FromQuery] ReadAllTeacherNotificationCommand command,CancellationToken token)
    {
        var response = await this.Mediator.Send(command,token);
        return response;

    }



}
