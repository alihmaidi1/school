using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Admin.ClassRoom.Banner.Command.Add;
using Admin.ClassRoom.Banner.Command.Delete;
using Admin.ClassRoom.Banner.Query.GetAll;
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
[CheckTokenSession(Policy = "Banner")]

public class BannerController:ApiController
{

    /// <summary>
    /// Get All Banner 
    /// </summary>
    /// <returns>return all role in pagination</returns>
   
    [Produces(typeof(OperationResultBase<PageList<GetAllBannerDto>>))]

    [HttpGet]
    public async Task<IActionResult> GetAll([FromQuery] GetAllBannerQuery command,CancellationToken Token)
    {
        var response = await this.Mediator.Send(command,Token);
        return response;

    }



    /// <summary>
    /// Add a New Banner 
    /// </summary>
    /// <returns>return all role in pagination</returns>
   
    [Produces(typeof(OperationResultBase<Boolean>))]

    [HttpPost]
    public async Task<IActionResult> Add([FromQuery] AddBannerCommand command,CancellationToken Token)
    {
        var response = await this.Mediator.Send(command,Token);
        return response;

    }


    /// <summary>
    /// Delete Banner 
    /// </summary>
    /// <returns>return all role in pagination</returns>
   
    [Produces(typeof(OperationResultBase<Boolean>))]

    [HttpDelete]
    public async Task<IActionResult> Delete([FromQuery] DeleteBannerCommand command,CancellationToken Token)
    {
        var response = await this.Mediator.Send(command,Token);
        return response;

    }

}
