using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Dto.Student;
using infrastructure.Attribute;
using Microsoft.AspNetCore.Mvc;
using schoolManagement.Base;
using Shared.Enum;
using Shared.OperationResult.Base;
using Shared.Swagger;
using Student.Home.Query.GetHome;
using Student.Subject.Query.GetAllLeson;
using Student.Subject.Query.GetAllQuez;

namespace schoolmanagment.Controllers.Student;

[ApiGroup(ApiGroupName.All, ApiGroupName.Student)]

[Route("Api/Student/[controller]/[action]")]

[CheckTokenSession(AuthenticationSchemes =nameof(JwtSchema.Student))]

public class HomeController:ApiController
{


    /// <summary>
    /// Get Student Home
    /// </summary>
    [HttpGet]
    [Produces(typeof(OperationResultBase<GetStudentHomeDto>))]

    public async Task<IActionResult> GetStudentHome([FromQuery] GetStudentHomeQuery command,CancellationToken Token)
    {
        var response = await this.Mediator.Send(command,Token);
        return response;

    }



    /// <summary>
    /// Get Student Leson
    /// </summary>
    [HttpGet]
    [Produces(typeof(OperationResultBase<GetAllStudentLesonDto>))]

    public async Task<IActionResult> GetAllLeson([FromQuery] GetAllLesonQuery command,CancellationToken Token)
    {
        var response = await this.Mediator.Send(command,Token);
        return response;

    }



    /// <summary>
    /// Get Student Quez
    /// </summary>
    [HttpGet]
    [Produces(typeof(OperationResultBase<GetAllStudentQuezDto>))]

    public async Task<IActionResult> GetAllQuez([FromQuery] GetAllQuezQuery command,CancellationToken Token)
    {
        var response = await this.Mediator.Send(command,Token);
        return response;

    }
}
