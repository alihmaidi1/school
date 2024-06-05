using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Dto.ClassRoom;
using Domain.Dto.Teacher;
using Dto.Admin.Teacher;
using infrastructure.Attribute;
using Microsoft.AspNetCore.Mvc;
using schoolManagement.Base;
using Shared.Entity.EntityOperation;
using Shared.OperationResult.Base;
using Shared.Swagger;
using Teacher.Quez.Query.GetAllQuez;
using Teacher.Subject.Query.GetAllAudience;
using Teacher.Subject.Query.GetAudienceDetail;
using Teacher.Subject.Query.GetOwned;
using Teacher.Subject.Query.GetWithStudent;

namespace schoolmanagment.Controllers.Teacher;


[ApiGroup(ApiGroupName.All, ApiGroupName.Teacher)]
[Microsoft.AspNetCore.Mvc.Route("Api/Teacher/[controller]/[action]")]
[CheckTokenSession()]

public class SubjectController: ApiController
{



    /// <summary>
    /// Get All Audience Date 
    /// </summary>
    [Produces(typeof(OperationResultBase<List<string>>))]
    [HttpGet]
    public async Task<IActionResult> GetAll([FromQuery] GetAllAudienceQuery command,CancellationToken token)
    {
        var response = await this.Mediator.Send(command,token);
        return response;

    }

    /// <summary>
    /// Get All subject name 
    /// </summary>
    [Produces(typeof(OperationResultBase<List<GetAllSubjectNameDto>>))]
    [HttpGet]
    public async Task<IActionResult> GetAllSubjectName([FromQuery] GetAllTeacherSubjectQuery command,CancellationToken token)
    {
        var response = await this.Mediator.Send(command,token);
        return response;

    }



    /// <summary>
    /// Get All Audience Detail 
    /// </summary>
    [Produces(typeof(OperationResultBase<List<GetAudienceDetailDto>>))]
    [HttpGet]
    public async Task<IActionResult> GetAudienceDetail([FromQuery] GetAudienceDetailQuery command,CancellationToken token)
    {
        var response = await this.Mediator.Send(command,token);
        return response;

    }


    /// <summary>
    /// get all Teacher  subject  and quez  in specific year 
    /// </summary>
    /// <returns>return all role in pagination</returns>
    [Produces(typeof(OperationResultBase<PageList<GetAllTeacherQuezDto>>))]
   
    [HttpGet]
    public async Task<IActionResult> GetAllTeacherQuezInSpecificYear([FromQuery] GetAllQuezQuery request,CancellationToken Token)
    {
        var response = await this.Mediator.Send(request,Token);
        return response;

    }

    /// <summary>
    /// Get All Audience Detail 
    /// </summary>
    [Produces(typeof(OperationResultBase<List<GetAllSubjectWithStudentTeacherDto>>))]
    [HttpGet]
    public async Task<IActionResult> GetAllSubjectAndStudent([FromQuery] GetAllSubjectWithStudentQuery command,CancellationToken token)
    {
        var response = await this.Mediator.Send(command,token);
        return response;

    }

}

