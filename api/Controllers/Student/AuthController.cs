using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dto.Admin.Auth.Dto;
using infrastructure.Attribute;
using Microsoft.AspNetCore.Mvc;
using schoolManagement.Base;
using Shared.Enum;
using Shared.OperationResult.Base;
using Shared.Swagger;
using Student.Auth.Command.Login;
using Student.Auth.Command.Logout;
using Student.Auth.Command.RefreshToken;
using Student.Auth.Command.ValidateCode;
using Teacher.Auth.Login;

namespace schoolmanagment.Controllers.Student;

[ApiGroup(ApiGroupName.All, ApiGroupName.Student)]

[Route("Api/Teacher/[controller]/[action]")]

public class AuthController:ApiController
{


    /// <summary>
    /// Login Student to App
    /// </summary>
    [HttpPost]
    [Produces(typeof(OperationResultBase<Boolean>))]

    public async Task<IActionResult> LoginStudent([FromBody] LoginStudentCommand command,CancellationToken Token)
    {
        var response = await this.Mediator.Send(command,Token);
        return response;

    }
    


    /// <summary>
    /// Validate Code And Get Token Info For Student
    /// </summary>
    [HttpPost]
    [Produces(typeof(OperationResultBase<AdminRefreshTokenDto>))]

    public async Task<IActionResult> ValidateCode([FromBody] ValidateCodeCommand command,CancellationToken Token)
    {
        var response = await this.Mediator.Send(command,Token);
        return response;

    }



    /// <summary>
    /// Logout Student
    /// </summary>
    [HttpPost]
    [Produces(typeof(OperationResultBase<AdminRefreshTokenDto>))]
    [CheckTokenSession(AuthenticationSchemes =nameof(JwtSchema.Student))]


    public async Task<IActionResult> Logout([FromBody] LogoutStudentCommand command,CancellationToken Token)
    {
        var response = await this.Mediator.Send(command,Token);
        return response;

    }

    /// <summary>
    /// Refresh Student Token
    /// </summary>
    [HttpPost]
    [Produces(typeof(OperationResultBase<AdminRefreshTokenDto>))]
    [CheckTokenSession(AuthenticationSchemes =nameof(JwtSchema.Student))]


    public async Task<IActionResult> RefreshToken([FromBody] RefreshStudentTokenCommand command,CancellationToken Token)
    {
        var response = await this.Mediator.Send(command,Token);
        return response;

    }


}
