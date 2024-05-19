using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Dto.ClassRoom;
using infrastructure.Attribute;
using Microsoft.AspNetCore.Mvc;
using schoolManagement.Base;
using Shared.OperationResult.Base;
using Shared.Swagger;
using Teacher.Subject.Query.GetAllAudience;
using Teacher.Subject.Query.GetAudienceDetail;

namespace schoolmanagment.Controllers.Teacher;


[ApiGroup(ApiGroupName.All, ApiGroupName.Teacher)]
[Microsoft.AspNetCore.Mvc.Route("Api/Teacher/[controller]/[action]")]
[CheckTokenSession()]

public class SubjectController: ApiController
{



    /// <summary>
    /// Get All Audience Date 
    /// </summary>
    [Produces(typeof(OperationResultBase<List<string>>))]
    [HttpGet]
    public async Task<IActionResult> GetAll([FromQuery] GetAllAudienceQuery command,CancellationToken token)
    {
        var response = await this.Mediator.Send(command,token);
        return response;

    }


    /// <summary>
    /// Get All Audience Detail 
    /// </summary>
    [Produces(typeof(OperationResultBase<List<GetAudienceDetailDto>>))]
    [HttpGet]
    public async Task<IActionResult> GetAudienceDetail([FromQuery] GetAudienceDetailQuery command,CancellationToken token)
    {
        var response = await this.Mediator.Send(command,token);
        return response;

    }
}
