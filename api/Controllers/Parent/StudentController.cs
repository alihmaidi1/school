using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Dto.Parent;
using Domain.Dto.Student;
using infrastructure.Attribute;
using Microsoft.AspNetCore.Mvc;
using Parent.Student.Query.FinalResult;
using Parent.Student.Query.GetAllName;
using schoolManagement.Base;
using Shared.Entity.EntityOperation;
using Shared.Enum;
using Shared.OperationResult.Base;
using Shared.Swagger;

namespace schoolmanagment.Controllers.Parent;


[ApiGroup(ApiGroupName.All, ApiGroupName.Parent)]

[Route("Api/Teacher/[controller]/[action]")]

[CheckTokenSession(AuthenticationSchemes =nameof(JwtSchema.Parent))]

public class StudentController: ApiController
{


        /// <summary>
    /// Get All Parent Student
    /// </summary>
    [HttpGet]
    [Produces(typeof(OperationResultBase<List<GetAllStudentNameDto>>))]

    public async Task<IActionResult> GetAllNotification([FromQuery] GetAllChildNameQuery command,CancellationToken Token)
    {
        var response = await this.Mediator.Send(command,Token);
        return response;

    }



    /// <summary>
    /// Get Student Final Result
    /// </summary>
    [HttpGet]
    [Produces(typeof(OperationResultBase<PageList<GetAllStudentResultDto>>))]

    public async Task<IActionResult> GetFinalResults([FromQuery] GetParentFinalResultQuery command,CancellationToken Token)
    {
        var response = await this.Mediator.Send(command,Token);
        return response;

    }

}
