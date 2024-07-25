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
using Teacher.Student.Query.GetUnHasMark;
using Teacher.Subject.Command.Add;

namespace schoolmanagment.Controllers.Teacher;

[ApiGroup(ApiGroupName.All, ApiGroupName.Teacher)]
[Microsoft.AspNetCore.Mvc.Route("Api/Teacher/[controller]/[action]")]

public class StudentController:ApiController
{


    /// <summary>
    /// Get All Student for Subject 
    /// </summary>
    [Produces(typeof(OperationResultBase<List<GetStudentNameDto>>))]
    [HttpGet]
    [CheckTokenSession(AuthenticationSchemes =nameof(JwtSchema.Teacher))]

    public async Task<IActionResult> GetAllStudentInActiveSubject([FromQuery] GetUnhaveMarkStudentQuery command,CancellationToken token)
    {
        var response = await this.Mediator.Send(command,token);
        return response;

    }


    /// <summary>
    /// Add Mark To Student
    /// </summary>
    [Produces(typeof(OperationResultBase<Boolean>))]
    [HttpPut]
    [CheckTokenSession(AuthenticationSchemes =nameof(JwtSchema.Teacher))]

    public async Task<IActionResult> AddMarkToStudent([FromQuery] AddMarkToStudentCommand command,CancellationToken token)
    {
        var response = await this.Mediator.Send(command,token);
        return response;

    }



}
