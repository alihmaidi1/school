using Admin.Teacher.Vacation.Command.ChangeStatus;
using Admin.Teacher.Warning.Command.Add;
using Admin.Teacher.Warning.Query.GetAll;
using Domain.AppMetaData.Admin;
using Domain.Attributes;
using Domain.Entities.Teacher.Warning;
using Domain.Enum;
using Microsoft.AspNetCore.Mvc;
using schoolmanagment.Base;
using Shared.Swagger;

namespace schoolmanagment.Controllers.Admin;


[ApiGroup(ApiGroupName.All, ApiGroupName.Admin)]
[AppAuthorize(Policy = nameof(PermissionEnum.Warning))]

public class WarningController:ApiController
{
    [HttpPost(WarningRouter.prefix)]
    public async Task<IActionResult> ChangeStatus([FromBody] AddWarningCommand request,CancellationToken Token)
    {
        var response = await this.Mediator.Send(request,Token);
        return response;

    }

    [HttpGet(WarningRouter.prefix)]
    public async Task<IActionResult> GetAll([FromQuery] GetAllWarningAdminQuery request,CancellationToken Token)
    {
        var response = await this.Mediator.Send(request,Token);
        return response;

    }

}