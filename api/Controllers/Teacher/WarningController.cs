using Admin.Teacher.Vacation.Command.Add;
using Domain.AppMetaData.Teacher;
using Domain.Attributes;
using Microsoft.AspNetCore.Mvc;
using schoolmanagment.Base;
using Shared.Swagger;
using Teacher.Warning.Query.GetAll;

namespace schoolmanagment.Controllers.Teacher;


[ApiGroup(ApiGroupName.All, ApiGroupName.Teacher)]
[TeacherAuthorizeAtrribute]
public class WarningController:ApiController
{
    
    [HttpPost(WarningRouter.prefix)]
    public async Task<IActionResult> GetAllWarings([FromQuery] GetWarningQuery request,CancellationToken Token)
    {
        var response = await this.Mediator.Send(request,Token);
        return response;

    }

    
}