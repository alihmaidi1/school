using Domain.AppMetaData.Teacher;

using Microsoft.AspNetCore.Mvc;
using schoolManagement.Base;
using Shared.Swagger;
using Teacher.Warning.Query.GetAll;

namespace schoolmanagment.Controllers.Teacher;


[ApiGroup(ApiGroupName.All, ApiGroupName.Teacher)]
// [TeacherAuthorizeAtrribute]
public class WarningController:ApiController
{
    
    [HttpPost(WarningRouter.prefix)]
    public async Task<IActionResult> GetAllWarings([FromQuery] GetWarningQuery request,CancellationToken Token)
    {
        var response = await this.Mediator.Send(request,Token);
        return response;

    }

    
}