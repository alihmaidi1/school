using Admin.Manager.Role.Command.Add;
using Admin.Teacher.Teacher.Command.Add;
using Admin.Teacher.Teacher.Command.Update;
using Admin.Teacher.Teacher.Query.GetAll;
using Domain.AppMetaData.Admin;
using Domain.Attributes;
using Domain.Enum;
using Microsoft.AspNetCore.Mvc;
using schoolmanagment.Base;
using Shared.Swagger;

namespace schoolmanagment.Controllers.Admin;

[ApiGroup(ApiGroupName.All, ApiGroupName.Admin)]
[AppAuthorize(Policy = nameof(PermissionEnum.Teacher))]
public class TeacherController:ApiController
{
    
    
    [HttpGet(TeacherRouter.prefix)]
    public async Task<IActionResult> GetAllTeacher([FromQuery] GetAllTeacherQuery request,CancellationToken Token)
    {
        var response = await this.Mediator.Send(request,Token);
        return response;

    }

    [HttpPost(TeacherRouter.prefix)]
    public async Task<IActionResult> AddTeacher([FromBody] AddTeacherCommand request,CancellationToken Token)
    {
        var response = await this.Mediator.Send(request,Token);
        return response;

    }

    
    [HttpPut(TeacherRouter.prefix)]
    public async Task<IActionResult> UpdateTeacher([FromBody] UpdateTeacherCommand request,CancellationToken Token)
    {
        var response = await this.Mediator.Send(request,Token);
        return response;
    }
}