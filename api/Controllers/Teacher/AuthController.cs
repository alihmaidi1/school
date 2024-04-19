using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dto.Admin.Auth.Dto;
using infrastructure.Attribute;
using Microsoft.AspNetCore.Mvc;
using schoolManagement.Base;
using Shared.OperationResult.Base;
using Shared.Swagger;
using Teacher.Auth.Login;
using Teacher.Auth.Logout;
using Teacher.Auth.RefreshToken;

namespace schoolmanagment.Controllers.Teacher;


[ApiGroup(ApiGroupName.All, ApiGroupName.Teacher)]

[Route("Api/Teacher/[controller]/[action]")]


public class AuthController: ApiController
{

    /// <summary>
    /// Login teacher to dashboard
    /// </summary>
    [HttpPost]
    [Produces(typeof(OperationResultBase<AdminRefreshTokenDto>))]

    public async Task<IActionResult> LoginTeacher([FromBody] LoginTeacherCommand command,CancellationToken Token)
    {
        var response = await this.Mediator.Send(command,Token);
        return response;

    }
    


    /// <summary>
    /// logout teacher from dashboard
    /// </summary>
    [HttpPost]
    [CheckTokenSession]

    [Produces(typeof(OperationResultBase<Boolean>))]

    public async Task<IActionResult> LogoutTeacher([FromBody] LogoutTeacherCommand command,CancellationToken Token)
    {
        var response = await this.Mediator.Send(command,Token);
        return response;

    }


   /// <summary>
    /// Refresh Teacher token and refresh token  for use at one time
    /// </summary>
    [HttpPost]
    [Produces(typeof(OperationResultBase<AdminRefreshTokenDto>))]

    public async Task<IActionResult> RefreshToken([FromBody] RefreshTokenTeacherCommand command)
    {
        var response =await this.Mediator.Send(command);
        return response;
    }



 

}
