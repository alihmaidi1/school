using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Admin.ClassRoom.Class.Query;
using Admin.ClassRoom.Class.Query.GetAllBill;
using Admin.ClassRoom.Class.Query.GetAllStageWithClasses;
using Domain.Dto.ClassRoom;
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
[CheckTokenSession(Policy = nameof(PermissionEnum.Subject))]

public class ClassController:ApiController
{


    /// <summary>
    /// get Final Result for class in specific year 
    /// </summary>
    /// <returns>return all role in pagination</returns>
   
    [Produces(typeof(OperationResultBase<PageList<GetAllResultDto>>))]

    [HttpGet]
    public async Task<IActionResult> GetAll([FromQuery] GetFinalResultQuery command,CancellationToken Token)
    {
        var response = await this.Mediator.Send(command,Token);
        return response;

    }


    /// <summary>
    /// get All Stage With Classes 
    /// </summary>
    /// <returns>return all role in pagination</returns>
   
    [Produces(typeof(OperationResultBase<List<GetAllStageAndClassesDto>>))]

    [HttpGet]
    public async Task<IActionResult> GetAllStageWithClasses([FromQuery] GetAllStageWithClassesQuery command,CancellationToken Token)
    {
        var response = await this.Mediator.Send(command,Token);
        return response;

    }

    /// <summary>
    /// get All Bill for  Class In specific year  
    /// </summary>
    /// <returns>return all role in pagination</returns>
   
    [Produces(typeof(OperationResultBase<List<GetAllStageAndClassesDto>>))]

    [HttpGet]
    public async Task<IActionResult> GetAllStudentBill([FromQuery] GetAllBillQuery command,CancellationToken Token)
    {
        var response = await this.Mediator.Send(command,Token);
        return response;

    }


}
