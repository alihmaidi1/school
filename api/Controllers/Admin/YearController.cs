using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Admin.ClassRoom.Year.Query.GetAll;
using Domain.Dto.ClassRoom;
using Domain.Enum;
using infrastructure.Attribute;
using Microsoft.AspNetCore.Mvc;
using schoolManagement.Base;
using Shared.OperationResult.Base;
using Shared.Swagger;

namespace schoolmanagment.Controllers.Admin;

[Route("Api/SuperAdmin/[controller]/[action]")]
[ApiGroup(ApiGroupName.All, ApiGroupName.Admin)]
[CheckTokenSession()]

public class YearController: ApiController
{
    /// <summary>
    /// get all year 
    /// </summary>
    /// <returns>return all role in pagination</returns>
    [Produces(typeof(OperationResultBase<List<GetAllYearDto>>))]
    [HttpGet]
    public async Task<IActionResult> GetAllYear(CancellationToken Token)
    {
        var response = await this.Mediator.Send(new GetAllYearQuery(),Token);
        return response;

    }


}
