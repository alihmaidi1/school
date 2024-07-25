using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Admin.ClassRoom.Year.Query.GetAll;
using Domain.Dto.ClassRoom;
using infrastructure.Attribute;
using Microsoft.AspNetCore.Mvc;
using schoolManagement.Base;
using Shared.Enum;
using Shared.OperationResult.Base;
using Shared.Swagger;

namespace schoolmanagment.Controllers.Teacher;


[ApiGroup(ApiGroupName.All, ApiGroupName.Teacher)]
[Microsoft.AspNetCore.Mvc.Route("Api/Teacher/[controller]/[action]")]

[CheckTokenSession(AuthenticationSchemes =nameof(JwtSchema.Teacher))]
public class YearController: ApiController
{
        /// <summary>
    /// get all year 
    /// </summary>
    /// <returns>return all role in pagination</returns>
    [Produces(typeof(OperationResultBase<List<GetAllYearDto>>))]
    [HttpGet]
    public async Task<IActionResult> GetAllTeacherYear(CancellationToken Token)
    {
        var response = await this.Mediator.Send(new GetAllYearQuery(),Token);
        return response;

    }


}
