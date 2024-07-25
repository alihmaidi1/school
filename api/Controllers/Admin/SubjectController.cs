using Admin.ClassRoom.Subject.Query.Get;
using Admin.ClassRoom.Subject.Query.GetActive;
using Admin.ClassRoom.Subject.Query.GetAll;
using Admin.ClassRoom.Subject.Query.GetAllByYear;
using Admin.ClassRoom.Subject.Query.GetAllName;
using Admin.ClassRoom.Subject.Query.GetAudience;
using Admin.ClassRoom.Subject.Query.GetSession;
using Admin.Teacher.Teacher.Query.GetAllSubject;
using Domain.Dto.ClassRoom;
using Domain.Dto.ClassRoom.Subject;
using Domain.Dto.Session;
using Domain.Dto.Teacher;
using Domain.Enum;
using infrastructure.Attribute;
using Microsoft.AspNetCore.Mvc;
using schoolManagement.Base;
using Shared.Entity.EntityOperation;
using Shared.Enum;
using Shared.OperationResult.Base;
using Shared.Swagger;

namespace schoolmanagment.Controllers.Admin;

[Route("Api/SuperAdmin/[controller]/[action]")]
[ApiGroup(ApiGroupName.All, ApiGroupName.Admin)]

public class SubjectController: ApiController
{


    /// <summary>
    /// get all Subject with Status  in this year 
    /// </summary>
    /// <returns>return all role in pagination</returns>
    [Produces(typeof(OperationResultBase<PageList<GetAllSubjectDto>>))]
    [CheckTokenSession(Policy = nameof(PermissionEnum.Subject))]
   
    [HttpGet]
    public async Task<IActionResult> GetAllSubjectWithStatus([FromQuery] GetAllSubjectCommand request,CancellationToken Token)
    {
        var response = await this.Mediator.Send(request,Token);
        return response;

    }


    /// <summary>
    /// get all Subject Name 
    /// </summary>
    /// <returns>return all role in pagination</returns>
    [Produces(typeof(OperationResultBase<List<GetAllSubjectNameDto>>))]
    [CheckTokenSession(Policy = nameof(PermissionEnum.Subject))]
   
    [HttpGet]
    public async Task<IActionResult> GetAllSubjectName(CancellationToken Token)
    {
        var response = await this.Mediator.Send(new GetAllSubjectNameQuery(),Token);
        return response;

    }



    /// <summary>
    /// get all active Subject Name 
    /// </summary>
    /// <returns>return all role in pagination</returns>
    [Produces(typeof(OperationResultBase<List<GetAllSubjectNameDto>>))]
    [CheckTokenSession(AuthenticationSchemes =nameof(JwtSchema.Admin))]
    [CheckTokenSession(AuthenticationSchemes =nameof(JwtSchema.Teacher))]
   
    [HttpGet]
    public async Task<IActionResult> GetAllActiveSubjectName([FromQuery]GetActiveSubjectQuery request,CancellationToken Token)
    {
        var response = await this.Mediator.Send(request,Token);
        return response;

    }



    /// <summary>
    /// get all Subject in specific year 
    /// </summary>
    /// <returns>return all role in pagination</returns>
    [Produces(typeof(OperationResultBase<GetAllSubjectByYearDto>))]
    [CheckTokenSession(Policy = nameof(PermissionEnum.Subject))]
   
    [HttpGet]
    public async Task<IActionResult> GetAllSubjectByYear([FromQuery] GetAllSubjectByYearQuery request,CancellationToken Token)
    {
        var response = await this.Mediator.Send(request,Token);
        return response;

    }



    /// <summary>
    /// get all Teacher By Subject 
    /// </summary>
    /// <returns>return all role in pagination</returns>
    [Produces(typeof(OperationResultBase<List<GetAllTeacherNameDto>>))]
    [CheckTokenSession()]
   
    [HttpGet]
    public async Task<IActionResult> GetAllTeacherBySubject([FromQuery] GetAllSubjectQuery request,CancellationToken Token)
    {
        var response = await this.Mediator.Send(request,Token);
        return response;

    }


    /// <summary>
    /// get Subject Detail in specific year 
    /// </summary>
    /// <returns>return all role in pagination</returns>
    [Produces(typeof(OperationResultBase<GetSubjectDetailDto>))]
    [CheckTokenSession(Policy = nameof(PermissionEnum.Subject))]
   
    [HttpGet]
    public async Task<IActionResult> GetSubjectDetail([FromQuery] GetSubjectDetailQuery request,CancellationToken Token)
    {
        var response = await this.Mediator.Send(request,Token);
        return response;

    }


    /// <summary>
    /// get Subject Session Number In Specific Year 
    /// </summary>
    /// <returns>return all role in pagination</returns>
    [Produces(typeof(OperationResultBase<GetSessionWithExistsStudentDto>))]
    [CheckTokenSession(AuthenticationSchemes =nameof(JwtSchema.Admin),Policy = nameof(PermissionEnum.Subject))]
    [CheckTokenSession(AuthenticationSchemes =nameof(JwtSchema.Teacher))]

    [HttpGet]
    public async Task<IActionResult> GetSessionNumber([FromQuery] GetSessionQuery request,CancellationToken Token)
    {
        var response = await this.Mediator.Send(request,Token);
        return response;

    }


    /// <summary>
    /// get Subject Audience In Specific Year 
    /// </summary>
    /// <returns>return all role in pagination</returns>
    [Produces(typeof(OperationResultBase<List<int>>))]
    [CheckTokenSession(Policy = nameof(PermissionEnum.Subject))]
   
    [HttpGet]
    public async Task<IActionResult> GetAudienceInSpecificSession([FromQuery] GetAudienceQuery request,CancellationToken Token)
    {
        var response = await this.Mediator.Send(request,Token);
        return response;

    }


}
