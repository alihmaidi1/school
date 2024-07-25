using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Dto;
using Domain.Dto.Student;
using Dto.Admin.Auth.Dto;
using infrastructure.Attribute;
using Microsoft.AspNetCore.Mvc;
using schoolManagement.Base;
using Shared.Enum;
using Shared.OperationResult.Base;
using Shared.Swagger;
using Student.Auth.Command.ChangePassword;
using Student.Auth.Command.CheckResetCode;
using Student.Auth.Command.ForgetPassword;
using Student.Auth.Command.Login;
using Student.Auth.Command.Logout;
using Student.Auth.Command.RefreshToken;
using Student.Auth.Command.ReSetCode;
using Student.Auth.Command.ValidateCode;
using Student.Home.Query.GetProfile;
using Teacher.Auth.Login;

namespace schoolmanagment.Controllers.Student;

[ApiGroup(ApiGroupName.All, ApiGroupName.Student)]

[Route("Api/Student/[controller]/[action]")]

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
    [Produces(typeof(OperationResultBase<Boolean>))]
    [CheckTokenSession(AuthenticationSchemes =nameof(JwtSchema.Student))]


    public async Task<IActionResult> Logout([FromBody] LogoutStudentCommand command,CancellationToken Token)
    {
        var response = await this.Mediator.Send(command,Token);
        return response;

    }


    /// <summary>
    /// Get Profile Parent
    /// </summary>
    [HttpGet]
    [Produces(typeof(OperationResultBase<GetProfileDto>))]
    [CheckTokenSession(AuthenticationSchemes =nameof(JwtSchema.Student))]


    public async Task<IActionResult> GetProfile(CancellationToken Token)
    {
        var response = await this.Mediator.Send(new GetProfileQuery(),Token);
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


    /// <summary>
    /// Forget Student Password
    /// </summary>
    [HttpPost]
    [Produces(typeof(OperationResultBase<Boolean>))]


    public async Task<IActionResult> ResetCode([FromBody] ForgetPasswordCommand command,CancellationToken Token)
    {
        var response = await this.Mediator.Send(command,Token);
        return response;

    }


    /// <summary>
    /// Check Reset Code
    /// </summary>
    [HttpPost]
    [Produces(typeof(OperationResultBase<AdminRefreshTokenDto>))]


    public async Task<IActionResult> CheckResetCode([FromBody] CheckResetCodeCommand command,CancellationToken Token)
    {
        var response = await this.Mediator.Send(command,Token);
        return response;

    }


    /// <summary>
    /// Change Password
    /// </summary>
    [HttpPost]
    [Produces(typeof(OperationResultBase<Boolean>))]
    [CheckTokenSession(AuthenticationSchemes =nameof(JwtSchema.Student))]

    public async Task<IActionResult> ChangePassword([FromBody] ChangePasswordCommand command,CancellationToken Token)
    {
        var response = await this.Mediator.Send(command,Token);
        return response;

    }




    /// <summary>
    /// Change Password
    /// </summary>
    [HttpPost]
    [Produces(typeof(OperationResultBase<Boolean>))]

    public async Task<IActionResult> ResetStudentCode([FromBody] ResetCodeCommand command,CancellationToken Token)
    {
        var response = await this.Mediator.Send(command,Token);
        return response;

    }


}
