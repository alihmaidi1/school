using Domain.Dto.Student;
using infrastructure.Attribute;
using Microsoft.AspNetCore.Mvc;
using schoolManagement.Base;
using Shared.Enum;
using Shared.OperationResult.Base;
using Shared.Swagger;
using Student.Quez.Command.SolveQuez;
using Student.Quez.Query.GetAll;
using Student.Quez.Query.GetFinishQuezInfo;
using Student.Quez.Query.GetQuezInfo;

namespace schoolmanagment.Controllers.Student;


[ApiGroup(ApiGroupName.All, ApiGroupName.Student)]

[Microsoft.AspNetCore.Mvc.Route("Api/Student/[controller]/[action]")]

[CheckTokenSession(AuthenticationSchemes =nameof(JwtSchema.Student))]

public class QuezController:ApiController
{

    /// <summary>
    /// Get Quez Info 
    /// </summary>
    [HttpGet]
    [Produces(typeof(OperationResultBase<GetQuezInfoDto>))]

    public async Task<IActionResult> GetQuezInfo([FromQuery] GetQuezInfoQuery command,CancellationToken Token)
    {
        var response = await this.Mediator.Send(command,Token);
        return response;

    }

    /// <summary>
    /// Get finish Quez Info 
    /// </summary>
    [HttpGet]
    [Produces(typeof(OperationResultBase<GetStudentFinishQuezDto>))]

    public async Task<IActionResult> GetFinishQuezInfo([FromQuery] GetFinishQuezInfoQuery command,CancellationToken Token)
    {
        var response = await this.Mediator.Send(command,Token);
        return response;

    }


    /// <summary>
    /// Solve Quez 
    /// </summary>
    [HttpPost]
    [Produces(typeof(OperationResultBase<Boolean>))]

    public async Task<IActionResult> SolveQuez([FromQuery] SolveQuezCommand command,CancellationToken Token)
    {
        var response = await this.Mediator.Send(command,Token);
        return response;

    }


    /// <summary>
    /// Solve Quez 
    /// </summary>
    [HttpGet]
    [Produces(typeof(OperationResultBase<GetAllStudentQuezDto.Quez>))]

    public async Task<IActionResult> GetAllActiveQuez(CancellationToken Token)
    {
        var response = await this.Mediator.Send(new GetAllQuezQuery(),Token);
        return response;

    }


}
