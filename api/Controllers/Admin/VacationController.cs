using Admin.Teacher.Vacation.Command.ChangeStatus;
using Admin.Teacher.Vacation.Query.GetAll;
using Domain.AppMetaData.Admin;
using Domain.Enum;
using infrastructure.Attribute;
using Microsoft.AspNetCore.Mvc;
using schoolManagement.Base;
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
    
    
    
    // [HttpGet(VacationRouter.prefix)]
    // public async Task<IActionResult> GetAll([FromQuery] GetVacationQuery request,CancellationToken Token)
    // {
    //     var response = await this.Mediator.Send(request,Token);
    //     return response;

    // }
}