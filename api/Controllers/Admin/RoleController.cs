using Admin.Manager.Role.Command.Add;
using Admin.Manager.Role.Command.Delete;
using Admin.Manager.Role.Command.Update;
using Admin.Manager.Role.Query.Get;
using Admin.Manager.Role.Query.GetAll;
using Admin.Manager.Role.Query.GetPermissions;
using Domain.AppMetaData.Admin;
using Domain.Dto.Manager.Admin;
using Domain.Dto.Manager.Role;
using Domain.Enum;
using infrastructure.Attribute;
using Microsoft.AspNetCore.Mvc;
using schoolManagement.Base;
using Shared.Entity.EntityOperation;
using Shared.OperationResult.Base;
using Shared.Swagger;

namespace schoolmanagment.Controllers.Admin;


[Route("Api/SuperAdmin/[controller]/[action]")]
[ApiGroup(ApiGroupName.All, ApiGroupName.Admin)]
[CheckTokenSession(Policy = "Role")]
public class RoleController:ApiController
{
    /// <summary>
    /// get all role 
    /// </summary>
    /// <returns>return all role in pagination</returns>
   
    [Produces(typeof(OperationResultBase<PageList<GetAllRoleDto>>))]

    [HttpGet]
    public async Task<IActionResult> GetAll([FromQuery] GetRolesQuery command,CancellationToken Token)
    {
        var response = await this.Mediator.Send(command,Token);
        return response;

    }
    
     /// <summary>
    /// get all admin by role id 
    /// </summary>
    /// <returns>return all admin in pagination</returns>
    [Produces(typeof(OperationResultBase<PageList<GetAllAdminByRoleDto>>))]
   
    [HttpGet]
    public async Task<IActionResult> GetAllAdminByRole([FromQuery] GetManagerByRoleQuery command,CancellationToken Token)
    {
        var response = await this.Mediator.Send(command,Token);
        return response;

    }

  /// <summary>
    /// get all Permission that you should use in add role 
    /// </summary>
    /// <returns>return all permissions</returns>
   
    [Produces(typeof(OperationResultBase<List<string>>))]

    [HttpGet]
    public async Task<IActionResult> GetPermissions(CancellationToken Token)
    {
        var response = await this.Mediator.Send(new GetPermissionsQuery(),Token);
        return response;

    }
    
     /// <summary>
    /// add a new role to use 
    /// </summary>
    /// <returns>return response true if operation is successed</returns>

    [HttpPost]

    [Produces(typeof(OperationResultBase<Boolean>))]

   
    public async Task<IActionResult> AddRole([FromBody] AddRoleCommand request,CancellationToken Token)
    {
        var response = await this.Mediator.Send(request,Token);
        return response;

    }
    
     /// <summary>
    ///  update role  
    /// </summary>
    /// <returns>return response true if operation is successed</returns>

    [HttpPut]
    public async Task<IActionResult> UpdateRole([FromBody] UpdateRoleCommand request,CancellationToken Token)
    {
        var response = await this.Mediator.Send(request,Token);
        return response;
    }
    

     /// <summary>
    /// delete role that not any admin use it 
    /// </summary>
    /// <returns>return response true if operation is successed</returns>

    [HttpDelete]
    
    [Produces(typeof(OperationResultBase<Boolean>))]

    public async Task<IActionResult> DeleteRole([FromQuery] DeleteRoleCommand request,CancellationToken Token)
    {
        var response = await this.Mediator.Send(request,Token);
        return response;
    }


}