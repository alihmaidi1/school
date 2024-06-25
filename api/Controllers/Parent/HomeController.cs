using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Dto.Parent;
using infrastructure.Attribute;
using Microsoft.AspNetCore.Mvc;
using Parent.Home.Query.GetHome;
using schoolManagement.Base;
using Shared.Enum;
using Shared.OperationResult.Base;
using Shared.Swagger;

namespace schoolmanagment.Controllers.Parent;

[ApiGroup(ApiGroupName.All, ApiGroupName.Parent)]

[Route("Api/Parent/[controller]/[action]")]

[CheckTokenSession(AuthenticationSchemes =nameof(JwtSchema.Parent))]

public class HomeController: ApiController
{



    /// <summary>
    /// Get Parent Home Page
    /// </summary>
    [HttpGet]
    [Produces(typeof(OperationResultBase<GetParentHomeDto>))]

    public async Task<IActionResult> GetHome([FromQuery] GetHomeQuery command,CancellationToken Token)
    {
        var response = await this.Mediator.Send(command,Token);
        return response;

    }

}
