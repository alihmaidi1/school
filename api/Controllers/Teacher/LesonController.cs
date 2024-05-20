
using Dto.Admin.Teacher;
using infrastructure.Attribute;
using Microsoft.AspNetCore.Mvc;
using schoolManagement.Base;
using Shared.OperationResult.Base;
using Shared.Swagger;
using Teacher.Leson.Command.Add;
using Teacher.Leson.Command.Delete;
using Teacher.Leson.Teacher.Leson.Query.GetAllLeson;

namespace schoolmanagment.Controllers.Teacher;


[ApiGroup(ApiGroupName.All, ApiGroupName.Teacher)]
[Route("Api/Teacher/[controller]/[action]")]
[CheckTokenSession]

public class LesonController: ApiController
{



    /// <summary>
    /// get all Teacher  subject  and leson  in specific year 
    /// </summary>
    /// <returns>return all role in pagination</returns>
    [Produces(typeof(OperationResultBase<List<GetAllTeacherLesonDto>>))]
   
    [HttpGet]
    public async Task<IActionResult> GetAllSubjectAndLeson([FromQuery] GetAllLesonQuery request,CancellationToken Token)
    {
        var response = await this.Mediator.Send(request,Token);
        return response;

    }

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
    public async Task<IActionResult> Delete([FromQuery] DeleteLesonCommand command,CancellationToken token)
    {
        var response = await this.Mediator.Send(command,token);
        return response;

    }
}
