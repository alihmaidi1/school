using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using infrastructure.Attribute;
using Microsoft.AspNetCore.Mvc;
using schoolManagement.Base;
using Shared.OperationResult.Base;
using Shared.Swagger;
using Teacher.Leson.Command.Add;

namespace schoolmanagment.Controllers.Teacher;


[ApiGroup(ApiGroupName.All, ApiGroupName.Teacher)]
[Route("Api/Teacher/[controller]/[action]")]
[CheckTokenSession]

public class LesonController: ApiController
{


    /// <summary>
    /// Create a new leson to specific subject in currect year
    /// </summary>
    [Produces(typeof(OperationResultBase<Boolean>))]
    [HttpPost]
    public async Task<IActionResult> Add([FromForm] AddLesonCommand command,CancellationToken token)
    {
        var response = await this.Mediator.Send(command,token);
        return response;

    }



    /// <summary>
    /// delete a leson to specific subject in currect year
    /// </summary>
    [Produces(typeof(OperationResultBase<Boolean>))]
    [HttpDelete]
    public async Task<IActionResult> delete([FromForm] AddLesonCommand command,CancellationToken token)
    {
        var response = await this.Mediator.Send(command,token);
        return response;

    }
}