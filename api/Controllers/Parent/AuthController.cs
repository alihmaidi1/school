using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Dto;
using Dto.Admin.Auth.Dto;
using infrastructure.Attribute;
using Microsoft.AspNetCore.Mvc;
using Parent.Auth.Command.ChangePassword;
using Parent.Auth.Command.CheckResetCode;
using Parent.Auth.Command.ForgetPassword;
using Parent.Auth.Command.Login;
using Parent.Auth.Command.Logout;
using Parent.Auth.Command.RefreshToken;
using Parent.Auth.Command.ReSetCode;
using Parent.Auth.Command.ValidateCode;
using Parent.Home.Query.GetProfile;
using schoolManagement.Base;
using Shared.Enum;
using Shared.OperationResult.Base;
using Shared.Swagger;

namespace schoolmanagment.Controllers.Parent;


[ApiGroup(ApiGroupName.All, ApiGroupName.Parent)]

[Route("Api/Parent/[controller]/[action]")]

public class AuthController:ApiController
{

    /// <summary>
    /// Login Parent to App
    /// </summary>
    [HttpPost]
    [Produces(typeof(OperationResultBase<Boolean>))]

    public async Task<IActionResult> LoginParent([FromBody] LoginParentCommand command,CancellationToken Token)
    {
        var response = await this.Mediator.Send(command,Token);
        return response;

    }

    /// <summary>
    /// Validate Code And Get Token Info For Parent
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
    [CheckTokenSession(AuthenticationSchemes =nameof(JwtSchema.Parent))]


    public async Task<IActionResult> Logout(CancellationToken Token)
    {
        var response = await this.Mediator.Send(new LogoutParentCommand(),Token);
        return response;

    }


    /// <summary>
    /// Get Profile Parent
    /// </summary>
    [HttpGet]
    [Produces(typeof(OperationResultBase<GetProfileDto>))]
    [CheckTokenSession(AuthenticationSchemes =nameof(JwtSchema.Parent))]


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
    [CheckTokenSession(AuthenticationSchemes =nameof(JwtSchema.Parent))]


    public async Task<IActionResult> RefreshToken([FromBody] RefreshParentTokenCommand command,CancellationToken Token)
    {
        var response = await this.Mediator.Send(command,Token);
        return response;

    }



    /// <summary>
    /// Forget Password Request
    /// </summary>
    [HttpPost]
    [Produces(typeof(OperationResultBase<Boolean>))]


    public async Task<IActionResult> ForgetPassword([FromBody] ForgetPasswordCommand command,CancellationToken Token)
    {
        var response = await this.Mediator.Send(command,Token);
        return response;

    }



    /// <summary>
    /// Check Code if exists and then return token info
    /// </summary>
    [HttpPost]
    [Produces(typeof(OperationResultBase<AdminRefreshTokenDto>))]


    public async Task<IActionResult> CheckResetCode([FromBody] CheckResetCodeCommand command,CancellationToken Token)
    {
        var response = await this.Mediator.Send(command,Token);
        return response;

    }



    /// <summary>
    /// Change Parent Password
    /// </summary>
    [HttpPut]
    [Produces(typeof(OperationResultBase<Boolean>))]
    [CheckTokenSession(AuthenticationSchemes =nameof(JwtSchema.Parent))]


    public async Task<IActionResult> ChangePassword([FromBody] ChangePasswordCommand command,CancellationToken Token)
    {
        var response = await this.Mediator.Send(command,Token);
        return response;

    }



    /// <summary>
    /// Reset Parent Code
    /// </summary>
    [HttpPut]
    [Produces(typeof(OperationResultBase<Boolean>))]


    public async Task<IActionResult> ResetParentCode([FromBody] ResetCodeCommand command,CancellationToken Token)
    {
        var response = await this.Mediator.Send(command,Token);
        return response;

    }
}
