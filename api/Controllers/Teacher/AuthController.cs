using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Domain.Dto.Teacher;
using Dto.Admin.Auth.Dto;
using infrastructure.Attribute;
using Microsoft.AspNetCore.Mvc;
using schoolManagement.Base;
using Shared.Enum;
using Shared.OperationResult.Base;
using Shared.Swagger;
using Teacher.Auth.GetProfile;
using Teacher.Auth.Login;
using Teacher.Auth.Logout;
using Teacher.Auth.RefreshToken;

namespace schoolmanagment.Controllers.Teacher;


[ApiGroup(ApiGroupName.All, ApiGroupName.Teacher)]

[Route("Api/Teacher/[controller]/[action]")]


public class AuthController: ApiController
{

    /// <summary>
    /// Get Profile Info
    /// </summary>
    [HttpGet]
    [Produces(typeof(OperationResultBase<GetAllTeacherDto>))]

    [CheckTokenSession(AuthenticationSchemes =nameof(JwtSchema.Teacher))]

    public async Task<IActionResult> GetTeacherInfo(CancellationToken Token)
    {
        var response = await this.Mediator.Send(new GetProfileQuery(),Token);
        return response;

    }
    


    // /// <summary>
    // /// logout teacher from dashboard
    // /// </summary>
    // [HttpPost]
    // [CheckTokenSession(AuthenticationSchemes =nameof(JwtSchema.Teacher))]

    // [Produces(typeof(OperationResultBase<Boolean>))]

    // public async Task<IActionResult> LogoutTeacher([FromBody] LogoutTeacherCommand command,CancellationToken Token)
    // {
    //     var response = await this.Mediator.Send(command,Token);
    //     return response;

    // }


//    /// <summary>
//     /// Refresh Teacher token and refresh token  for use at one time
//     /// </summary>
//     [HttpPost]
//     [Produces(typeof(OperationResultBase<AdminRefreshTokenDto>))]

//     public async Task<IActionResult> RefreshToken([FromBody] RefreshTokenTeacherCommand command)
//     {
//         var response =await this.Mediator.Send(command);
//         return response;
//     }



 

}
