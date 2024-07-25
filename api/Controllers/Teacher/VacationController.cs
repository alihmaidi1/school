using Admin.Teacher.Vacation.Command.Add;
using Domain.AppMetaData.Teacher;
using infrastructure.Attribute;
using Microsoft.AspNetCore.Mvc;
using schoolManagement.Base;
using Shared.Enum;
using Shared.OperationResult.Base;
using Shared.Swagger;
using Teacher.Vacation.Command.Request;
using Teacher.Vacation.Query.GetAllVacationType;

namespace schoolmanagment.Controllers.Teacher;



[ApiGroup(ApiGroupName.All, ApiGroupName.Teacher)]
[Microsoft.AspNetCore.Mvc.Route("Api/Teacher/[controller]/[action]")]

[CheckTokenSession(AuthenticationSchemes =nameof(JwtSchema.Teacher))]
public class VacationController:ApiController
{
    

    /// <summary>
    /// Get All Vacation Type
    /// </summary>
    [Produces(typeof(OperationResultBase<Boolean>))]
    [HttpPost]
    public async Task<IActionResult> GetAllVacationTypes(CancellationToken Token)
    {
        var response = await this.Mediator.Send(new GetAllVacationTypeQuery(),Token);
        return response;

    }



    /// <summary>
    /// request a new vacation from admin
    /// </summary>
    [Produces(typeof(OperationResultBase<Boolean>))]
    [HttpPost]
    public async Task<IActionResult> Add([FromForm] RequestVacationCommand command,CancellationToken token)
    {
        var response = await this.Mediator.Send(command,token);
        return response;

    }

    
}