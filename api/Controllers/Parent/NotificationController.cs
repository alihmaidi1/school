using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Dto.Notification;
using infrastructure.Attribute;
using Microsoft.AspNetCore.Mvc;
using Parent.Notification.Command.Delete;
using Parent.Notification.Query.GetAll;
using schoolManagement.Base;
using Shared.Entity.EntityOperation;
using Shared.Enum;
using Shared.OperationResult.Base;
using Shared.Swagger;

namespace schoolmanagment.Controllers.Parent;

[ApiGroup(ApiGroupName.All, ApiGroupName.Parent)]

[Route("Api/Teacher/[controller]/[action]")]

[CheckTokenSession(AuthenticationSchemes =nameof(JwtSchema.Parent))]

public class NotificationController:ApiController
{


        /// <summary>
    /// Get All Parent Notification
    /// </summary>
    [HttpGet]
    [Produces(typeof(OperationResultBase<PageList<GetAllNotificationDto>>))]

    public async Task<IActionResult> GetAllNotification([FromQuery] GetAllNotificationQuery command,CancellationToken Token)
    {
        var response = await this.Mediator.Send(command,Token);
        return response;

    }


    /// <summary>
    /// Delete Parent Notification
    /// </summary>
    [HttpDelete]
    [Produces(typeof(OperationResultBase<Boolean>))]

    public async Task<IActionResult> Delete([FromQuery] DeleteNotificationCommand command,CancellationToken Token)
    {
        var response = await this.Mediator.Send(command,Token);
        return response;

    }


}
