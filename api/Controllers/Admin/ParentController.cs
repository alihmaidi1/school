using Admin.Manager.Role.Query.GetAll;
using Admin.Student.Parent.Command.Add;
using Admin.Student.Parent.Query.GetAll;
using Domain.AppMetaData.Admin;

using Microsoft.AspNetCore.Mvc;
using schoolManagement.Base;
using Shared.Swagger;

namespace schoolmanagment.Controllers.Admin;



[ApiGroup(ApiGroupName.All, ApiGroupName.Admin)]
// [AppAuthorize(Policy = nameof(PermissionEnum.Parent))]
public class ParentController:ApiController
{
    
    [HttpGet(ParentRouter.prefix)]
    public async Task<IActionResult> GetAllParent([FromQuery] GetAllParentsQuery command,CancellationToken Token)
    {
        var response = await this.Mediator.Send(command,Token);
        return response;
    
    }

    
    [HttpPost(ParentRouter.prefix)]
    public async Task<IActionResult> AddParent([FromBody] AddParentCommand command,CancellationToken Token)
    {
        var response = await this.Mediator.Send(command,Token);
        return response;
    
    }
    
    
}