using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Admin.ClassRoom.Class.Command.AddBill;
using Admin.ClassRoom.Class.Command.FinishYear;
using Admin.ClassRoom.Class.Query;
using Admin.ClassRoom.Class.Query.GetActiveYear;
using Admin.ClassRoom.Class.Query.GetAllBill;
using Admin.ClassRoom.Class.Query.GetAllStageWithClasses;
using Admin.ClassRoom.Class.Query.GetUnActiveYear;
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
    public async Task<IActionResult> GetFinalResult([FromQuery] GetFinalResultQuery command,CancellationToken Token)
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
    public async Task<IActionResult> GetAllStageWithClasses(CancellationToken Token)
    {
        var response = await this.Mediator.Send(new GetAllStageWithClassesQuery(),Token);
        return response;

    }



    /// <summary>
    /// get All Active Classes 
    /// </summary>
    /// <returns>return all role in pagination</returns>
   
    [Produces(typeof(OperationResultBase<List<GetAllActiveClassDto>>))]

    [HttpGet]
    public async Task<IActionResult> GetAllActiveClasses(CancellationToken Token)
    {
        var response = await this.Mediator.Send(new GetActiveClassQuery(),Token);
        return response;

    }



    /// <summary>
    /// get All UnActive Classes 
    /// </summary>
    /// <returns>return all role in pagination</returns>
   
    [Produces(typeof(OperationResultBase<List<GetUnActiveClassDto>>))]

    [HttpGet]
    public async Task<IActionResult> GetAllUnActiveClasses(CancellationToken Token)
    {
        var response = await this.Mediator.Send(new GetUnActiveClassQuery(),Token);
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



    /// <summary>
    /// Add a New Bill to Specific class in active year  
    /// </summary>
    /// <returns>return all role in pagination</returns>
   
    [Produces(typeof(OperationResultBase<Boolean>))]

    [HttpPost]
    public async Task<IActionResult> AddBill([FromBody] AddBillCommand command,CancellationToken Token)
    {
        var response = await this.Mediator.Send(command,Token);
        return response;

    }


    /// <summary>
    /// Finish class year   
    /// </summary>
    /// <returns>return all role in pagination</returns>
   
    [Produces(typeof(OperationResultBase<Boolean>))]

    [HttpPut]
    public async Task<IActionResult> FinishClassYear([FromBody] FinishYearCommand command,CancellationToken Token)
    {
        var response = await this.Mediator.Send(command,Token);
        return response;

    }


}
