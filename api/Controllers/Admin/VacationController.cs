using Admin.Teacher.Vacation.Command.ChangeStatus;
using Admin.Teacher.Vacation.Query.GetAll;
using Domain.AppMetaData.Admin;

using Microsoft.AspNetCore.Mvc;
using schoolManagement.Base;
using Shared.Swagger;

namespace schoolmanagment.Controllers.Admin;



[ApiGroup(ApiGroupName.All, ApiGroupName.Admin)]
// [AppAuthorize(Policy = nameof(PermissionEnum.Vacation))]
public class VacationController:ApiController
{
    
    
    
    [HttpPost(VacationRouter.prefix)]
    public async Task<IActionResult> ChangeStatus([FromBody] ChnageVacationStatusCommand request,CancellationToken Token)
    {
        var response = await this.Mediator.Send(request,Token);
        return response;

    }
    
    
    
    [HttpGet(VacationRouter.prefix)]
    public async Task<IActionResult> GetAll([FromQuery] GetVacationQuery request,CancellationToken Token)
    {
        var response = await this.Mediator.Send(request,Token);
        return response;

    }
}