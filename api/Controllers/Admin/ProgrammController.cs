using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Admin.ClassRoom.Programm.Command.Add;
using Admin.ClassRoom.Programm.Query.GetAll;
using Domain.Dto.ClassRoom;
using Domain.Enum;
using infrastructure.Attribute;
using Microsoft.AspNetCore.Mvc;
using schoolManagement.Base;
using Shared.OperationResult.Base;
using Shared.Swagger;

namespace schoolmanagment.Controllers.Admin;

[Microsoft.AspNetCore.Mvc.Route("Api/SuperAdmin/[controller]/[action]")]
[ApiGroup(ApiGroupName.All, ApiGroupName.Admin)]
[CheckTokenSession(Policy = nameof(PermissionEnum.Programm))]

public class ProgrammController: ApiController
{

    /// <summary>
    /// get all programm 
    /// </summary>
    /// <returns>return all role in pagination</returns>
   
    [Produces(typeof(OperationResultBase<List<GetAllProgrammDto>>))]

    [HttpGet]
    public async Task<IActionResult> GetAll([FromQuery] GetAllProgrammQuery command,CancellationToken Token)
    {
        var response = await this.Mediator.Send(command,Token);
        return response;

    }


    /// <summary>
    /// Add programm to Class In This Year 
    /// </summary>
    /// <returns>return all role in pagination</returns>
   
    [Produces(typeof(OperationResultBase<Boolean>))]

    [HttpPost]
    public async Task<IActionResult> Add([FromBody] AddProgrammCommand command,CancellationToken Token)
    {
        var response = await this.Mediator.Send(command,Token);
        return response;

    }



}
