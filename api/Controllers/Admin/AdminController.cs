using Admin.Manager.Admin.Command.Add;
using Admin.Manager.Admin.Command.ChangeStatus;
using Admin.Manager.Admin.Command.Delete;
using Admin.Manager.Admin.Command.Update;
using Admin.Manager.Admin.Query.Get;
using Admin.Manager.Admin.Query.GetAll;
using Domain.AppMetaData.Admin;
using Domain.Enum;
using Dto.Admin.Admin;
using infrastructure.Attribute;
using Microsoft.AspNetCore.Mvc;
using schoolManagement.Base;
using Shared.Entity.EntityOperation;
using Shared.OperationResult.Base;
using Shared.Swagger;

namespace schoolmanagment.Controllers.Admin;

[Route("Api/SuperAdmin/[controller]/[action]")]
[ApiGroup(ApiGroupName.All, ApiGroupName.Admin)]
[CheckTokenSession(Policy = nameof(PermissionEnum.Admin))]
public class AdminController:ApiController
{
    
    
    /// <summary>
    /// Get All Admin With Role Name
    /// </summary>
    [HttpGet]
    [Produces(typeof(OperationResultBase<PageList<GetAllAdmin>>))]

    public async Task<IActionResult> GetAllAdmin(GetAllAdminQuery command,CancellationToken token)
    {
        var response = await this.Mediator.Send(command,token);
        return response;
    }

    


    /// <summary>
    /// Get  Admin With Role Name
    /// </summary>    
    [HttpGet]

    [Produces(typeof(OperationResultBase<GetAdminInfo>))]

    public async Task<IActionResult> GetAdmin( Guid id,CancellationToken token)
    {
        var response = await this.Mediator.Send(new GetAdminQuery(id),token);
        return response;

    }
    
    /// <summary>
    /// Create a new admin and notify him
    /// </summary>
    [Produces(typeof(OperationResultBase<Boolean>))]
    [HttpPost]
    public async Task<IActionResult> Add([FromBody] AddAdminCommand command,CancellationToken token)
    {
        var response = await this.Mediator.Send(command,token);
        return response;

    }
    

    /// <summary>
    /// update admin info
    /// </summary>
    [HttpPut]
    [Produces(typeof(OperationResultBase<Boolean>))]

    
    public async Task<IActionResult> updateAdmin([FromBody] UpdateAdminCommand command,CancellationToken Token)
    {
        var response = await this.Mediator.Send(command,Token);
        return response;

    }
    

    /// <summary>
    /// update admin status
    /// </summary>
    [HttpPut]
    [Produces(typeof(OperationResultBase<Boolean>))]

    public async Task<IActionResult> updateAdminStatus([FromBody] ChangeAdminStatusCommand command,CancellationToken Token)
    {
        var response = await this.Mediator.Send(command,Token);
        return response;

    }
    

    /// <summary>
    /// Delete  admin
    /// </summary>
    [HttpDelete]
    [Produces(typeof(OperationResultBase<Boolean>))]

    public async Task<IActionResult> DeleteAdmin(Guid id,CancellationToken Token)
    {
     
        var response = await this.Mediator.Send(new DeleteAdminCommand(id),Token);
        return response;

    }
}