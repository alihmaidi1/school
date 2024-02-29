using Admin.Admin.Command.AddAdmin;
using Admin.Admin.Query.GetAll;
using Admin.Auth.Command.Login;
using Admin.Manager.Admin.Command.Delete;
using Admin.Manager.Admin.Command.Update;
using Admin.Manager.Admin.Query.Get;
using Domain.AppMetaData.Admin;
using Domain.Attributes;
using Domain.Enum;
using Microsoft.AspNetCore.Mvc;
using schoolmanagment.Base;
using Shared.Swagger;

namespace schoolmanagment.Controllers.Admin;

[ApiGroup(ApiGroupName.All, ApiGroupName.Admin)]
[AppAuthorize(Policy = nameof(PermissionEnum.Admin))]
public class AdminController:ApiController
{
    
    [HttpGet(AdminRouter.prefix)]


    public async Task<IActionResult> GetAllAdmin([FromQuery] GetAllAdminQuery command,CancellationToken Token)
    {
        var response = await this.Mediator.Send(command,Token);
        return response;

    }

    
    
    [HttpGet(AdminRouter.Get)]


    public async Task<IActionResult> GetAdmin( Guid id,CancellationToken Token)
    {
        var response = await this.Mediator.Send(new GetAdminQuery(id),Token);
        return response;

    }
    
    [HttpPost(AdminRouter.prefix)]
    public async Task<IActionResult> AddAdmin([FromBody] AddAdminCommand command,CancellationToken Token)
    {
        var response = await this.Mediator.Send(command,Token);
        return response;

    }
    
    [HttpPut(AdminRouter.prefix)]
    public async Task<IActionResult> updateAdmin([FromBody] UpdateAdminCommand command,CancellationToken Token)
    {
        var response = await this.Mediator.Send(command,Token);
        return response;

    }
    
    
    [HttpDelete(AdminRouter.Get)]
    public async Task<IActionResult> DeleteAdmin(Guid id,CancellationToken Token)
    {
     
        var response = await this.Mediator.Send(new DeleteAdminCommand(id),Token);
        return response;

    }
}