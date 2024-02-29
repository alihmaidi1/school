using Admin.Manager.Role.Command.Add;
using Admin.Manager.Role.Command.Delete;
using Admin.Manager.Role.Command.Update;
using Admin.Manager.Role.Query.Get;
using Admin.Manager.Role.Query.GetAll;
using Admin.Manager.Role.Query.GetPermissions;
using Domain.AppMetaData.Admin;
using Domain.Attributes;
using Domain.Enum;
using Microsoft.AspNetCore.Mvc;
using schoolmanagment.Base;
using Shared.Swagger;

namespace schoolmanagment.Controllers.Admin;


[ApiGroup(ApiGroupName.All, ApiGroupName.Admin)]
[AppAuthorize(Policy = nameof(PermissionEnum.Role))]
public class RoleController:ApiController
{
    
    [HttpGet(RoleRouter.prefix)]
    public async Task<IActionResult> AddAdmin([FromQuery] GetRolesQuery command,CancellationToken Token)
    {
        var response = await this.Mediator.Send(command,Token);
        return response;

    }
    
    [HttpGet(RoleRouter.Admins)]
    public async Task<IActionResult> AddAdmin([FromQuery] GetManagerByRoleQuery command,CancellationToken Token)
    {
        var response = await this.Mediator.Send(command,Token);
        return response;

    }

    [HttpGet(RoleRouter.Permission)]
    public async Task<IActionResult> GetPermissions(CancellationToken Token)
    {
        var response = await this.Mediator.Send(new GetPermissionsQuery(),Token);
        return response;

    }
    
    
    [HttpPost(RoleRouter.prefix)]
    public async Task<IActionResult> AddRole([FromBody] AddRoleCommand request,CancellationToken Token)
    {
        var response = await this.Mediator.Send(request,Token);
        return response;

    }
    
    [HttpPut(RoleRouter.prefix)]
    public async Task<IActionResult> UpdateRole([FromBody] UpdateRoleCommand request,CancellationToken Token)
    {
        var response = await this.Mediator.Send(request,Token);
        return response;
    }
    
    
    [HttpDelete(RoleRouter.prefix)]
    public async Task<IActionResult> DeleteRole([FromQuery] DeleteRoleCommand request,CancellationToken Token)
    {
        var response = await this.Mediator.Send(request,Token);
        return response;
    }


}