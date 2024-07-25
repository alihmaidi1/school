using Admin.Teacher.Vacation.Command.ChangeStatus;
using Admin.Teacher.Vacation.Query.GetAll;
using Admin.Teacher.VacationType.Command.Add;
using Admin.Teacher.VacationType.Command.Delete;
using Admin.Teacher.VacationType.Query.GetAll;
using Domain.AppMetaData.Admin;
using Domain.Dto.Teacher;
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
[CheckTokenSession(Policy = nameof(PermissionEnum.Vacation))]

public class VacationController:ApiController
{
    
    
    
    /// <summary>
    /// Change Vacation Status  
    /// </summary>
    /// <returns></returns>

    [HttpPut]
    public async Task<IActionResult> ChangeStatus([FromQuery] ChnageVacationStatusCommand request,CancellationToken Token)
    {
        var response = await this.Mediator.Send(request,Token);
        return response;

    }
    
    

    /// <summary>
    /// Add a new Vacation Type  
    /// </summary>
    /// <returns></returns>

    [Produces(typeof(OperationResultBase<Boolean>))]

    [HttpPost]
    public async Task<IActionResult> AddVacationType([FromQuery] AddVacationTypeCommand request,CancellationToken Token)
    {
        var response = await this.Mediator.Send(request,Token);
        return response;

    }
    
    
    

    /// <summary>
    /// Get All Vacation Type  
    /// </summary>
    /// <returns></returns>

    [Produces(typeof(OperationResultBase<PageList<GetAllVacationTypeDto>>))]

    [HttpPost]
    public async Task<IActionResult> GetAllVacationTypes([FromQuery] GetAllVacationTypeQuery request,CancellationToken Token)
    {
        var response = await this.Mediator.Send(request,Token);
        return response;

    }
    
    

    /// <summary>
    /// Delete Vacation Type  
    /// </summary>
    /// <returns></returns>

    [Produces(typeof(OperationResultBase<Boolean>))]
    [HttpDelete]
    public async Task<IActionResult> DeleteVacationType([FromQuery] DeleteVacationTypeCommand request,CancellationToken Token)
    {
        var response = await this.Mediator.Send(request,Token);
        return response;

    }
    
    
    

    /// <summary>
    /// Get All Vacation  
    /// </summary>
    /// <returns></returns>

    [Produces(typeof(OperationResultBase<List<GetAllVacationDto>>))]
    
    [HttpGet]
    public async Task<IActionResult> GetAll([FromQuery] GetVacationQuery request,CancellationToken Token)
    {
        var response = await this.Mediator.Send(request,Token);
        return response;

    }
}