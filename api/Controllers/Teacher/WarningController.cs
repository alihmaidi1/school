using Domain.AppMetaData.Teacher;
using infrastructure.Attribute;
using Microsoft.AspNetCore.Mvc;
using schoolManagement.Base;
using Shared.Enum;
using Shared.Swagger;
using Teacher.Warning.Query.GetAll;

namespace schoolmanagment.Controllers.Teacher;


[ApiGroup(ApiGroupName.All, ApiGroupName.Teacher)]

[CheckTokenSession(AuthenticationSchemes =nameof(JwtSchema.Teacher))]
public class WarningController:ApiController
{
    
    [HttpPost(WarningRouter.prefix)]
    public async Task<IActionResult> GetAllWarings([FromQuery] GetWarningQuery request,CancellationToken Token)
    {
        var response = await this.Mediator.Send(request,Token);
        return response;

    }

    
}