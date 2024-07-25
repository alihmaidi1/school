using Admin.ClassRoom.Year.Command.Add;
using Admin.ClassRoom.Year.Query.GetAll;
using Domain.Dto.ClassRoom;
using infrastructure.Attribute;
using Microsoft.AspNetCore.Mvc;
using schoolManagement.Base;
using Shared.Enum;
using Shared.OperationResult.Base;
using Shared.Swagger;

namespace schoolmanagment.Controllers.Admin;

[Route("Api/SuperAdmin/[controller]/[action]")]
[ApiGroup(ApiGroupName.All, ApiGroupName.Admin)]

public class YearController: ApiController
{


    [CheckTokenSession(AuthenticationSchemes =$"{nameof(JwtSchema.Admin)},{nameof(JwtSchema.Teacher)}")]

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



    /// <summary>
    /// Add New Year 
    /// </summary>
    /// <returns>return all role in pagination</returns>
    [Produces(typeof(OperationResultBase<List<GetAllYearDto>>))]
    [HttpPost]
    [CheckTokenSession()]

    public async Task<IActionResult> AddYear([FromBody] AddYearCommand request,CancellationToken Token)
    {
        var response = await this.Mediator.Send(request,Token);
        return response;

    }


}
