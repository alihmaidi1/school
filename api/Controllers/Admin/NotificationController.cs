using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Admin.Notification.Command.Send;
using Admin.Notification.Query.ReadAll;
using Domain.Dto.Notification;
using Domain.Enum;
using infrastructure.Attribute;
using Microsoft.AspNetCore.Mvc;
using schoolManagement.Base;
using Shared.Entity.EntityOperation;
using Shared.OperationResult.Base;
using Shared.Swagger;

namespace schoolmanagment.Controllers.Admin;



[Microsoft.AspNetCore.Mvc.Route("Api/SuperAdmin/[controller]/[action]")]
[ApiGroup(ApiGroupName.All, ApiGroupName.Admin)]
[CheckTokenSession(Policy = nameof(PermissionEnum.Notification))]
public class NotificationController: ApiController
{

    /// <summary>
    /// get all Notification  
    /// </summary>
    /// <returns>return all role in pagination</returns>
    [Produces(typeof(OperationResultBase<List<GetAllNotificationDto>>))]   
    [HttpGet]
    public async Task<IActionResult> GetAllNotification([FromQuery] ReadAllAdminNotificationCommand command,CancellationToken Token)
    {
        var response = await this.Mediator.Send(command,Token);
        return response;
    
    }


   /// <summary>
    /// Send Notification to Another User  
    /// </summary>
    /// <returns>return all role in pagination</returns>
    [Produces(typeof(OperationResultBase<Boolean>))]   
    [HttpPost]
    public async Task<IActionResult> Send([FromBody] SendNotificationCommand command,CancellationToken Token)
    {
        var response = await this.Mediator.Send(command,Token);
        return response;
    
    }



}
