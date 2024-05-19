using Admin.Manager.Role.Query.GetAll;
using Admin.Student.Parent.Command.Add;
using Admin.Student.Parent.Command.Delete;
using Admin.Student.Parent.Command.Update;
using Admin.Student.Parent.Query.GetAll;
using Admin.Student.Parent.Query.GetStudent;
using Domain.AppMetaData.Admin;
using Domain.Dto.Student;
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
[CheckTokenSession(Policy = nameof(PermissionEnum.Parent))]

public class ParentController:ApiController
{
    

    /// <summary>
    /// get all Parent  
    /// </summary>
    /// <returns>return all role in pagination</returns>
    [Produces(typeof(OperationResultBase<PageList<GetAllParentDto>>))]   
    [HttpGet]
    public async Task<IActionResult> GetAllParent([FromQuery] GetAllParentsQuery command,CancellationToken Token)
    {
        var response = await this.Mediator.Send(command,Token);
        return response;
    
    }



    /// <summary>
    /// get all student By Parent  
    /// </summary>
    /// <returns>return all role in pagination</returns>
    [Produces(typeof(OperationResultBase<List<GetAllStudentParentDto>>))]   
    [HttpGet]
    public async Task<IActionResult> GetAllStudentByParent([FromQuery] GetAllParentStudentQuery command,CancellationToken Token)
    {
        var response = await this.Mediator.Send(command,Token);
        return response;
    
    }

    /// <summary>
    /// Add a new Parent to this school  
    /// </summary>
    /// <returns>return all role in pagination</returns>
    
    [HttpPost]
    public async Task<IActionResult> AddParent([FromBody] AddParentCommand command,CancellationToken Token)
    {
        var response = await this.Mediator.Send(command,Token);
        return response;
    
    }
    
    /// <summary>
    /// Delete Parent from this school  
    /// </summary>
    /// <returns>return all role in pagination</returns>
    
    [HttpDelete]
    public async Task<IActionResult> DeleteParent([FromQuery] DeleteParentCommand command,CancellationToken Token)
    {
        var response = await this.Mediator.Send(command,Token);
        return response;
    
    }
 

   /// <summary>
    /// Update Parent info in this school  
    /// </summary>
    /// <returns>return all role in pagination</returns>
    
    [HttpDelete]
    public async Task<IActionResult> UpdateParent([FromQuery] UpdateParentCommand command,CancellationToken Token)
    {
        var response = await this.Mediator.Send(command,Token);
        return response;
    
    }
 

}