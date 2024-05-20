using Admin.ClassRoom.Subject.Query.Get;
using Admin.ClassRoom.Subject.Query.GetAll;
using Admin.ClassRoom.Subject.Query.GetAllByYear;
using Admin.ClassRoom.Subject.Query.GetAllName;
using Domain.Dto.ClassRoom;
using Domain.Dto.ClassRoom.Subject;
using Domain.Enum;
using infrastructure.Attribute;
using Microsoft.AspNetCore.Mvc;
using schoolManagement.Base;
using Shared.Entity.EntityOperation;
using Shared.OperationResult.Base;
using Shared.Swagger;

namespace schoolmanagment.Controllers.Admin;

[Route("Api/SuperAdmin/[controller]/[action]")]
[ApiGroup(ApiGroupName.All, ApiGroupName.Admin)]
[CheckTokenSession(Policy = nameof(PermissionEnum.Subject))]

public class SubjectController: ApiController
{


    /// <summary>
    /// get all Subject with Status  in this year 
    /// </summary>
    /// <returns>return all role in pagination</returns>
    [Produces(typeof(OperationResultBase<PageList<GetAllSubjectDto>>))]
   
    [HttpGet]
    public async Task<IActionResult> GetAllTeacher([FromQuery] GetAllSubjectCommand request,CancellationToken Token)
    {
        var response = await this.Mediator.Send(request,Token);
        return response;

    }


    /// <summary>
    /// get all Subject Name 
    /// </summary>
    /// <returns>return all role in pagination</returns>
    [Produces(typeof(OperationResultBase<List<GetAllSubjectNameDto>>))]
   
    [HttpGet]
    public async Task<IActionResult> GetAllSubjectName(CancellationToken Token)
    {
        var response = await this.Mediator.Send(new GetAllSubjectNameQuery(),Token);
        return response;

    }


    /// <summary>
    /// get all Subject in specific year 
    /// </summary>
    /// <returns>return all role in pagination</returns>
    [Produces(typeof(OperationResultBase<GetAllSubjectByYearDto>))]
   
    [HttpGet]
    public async Task<IActionResult> GetAllSubjectByYear([FromQuery] GetAllSubjectByYearQuery request,CancellationToken Token)
    {
        var response = await this.Mediator.Send(request,Token);
        return response;

    }

    /// <summary>
    /// get Subject Detail in specific year 
    /// </summary>
    /// <returns>return all role in pagination</returns>
    [Produces(typeof(OperationResultBase<GetSubjectDetailDto>))]
   
    [HttpGet]
    public async Task<IActionResult> GetSubjectDetail([FromQuery] GetSubjectDetailQuery request,CancellationToken Token)
    {
        var response = await this.Mediator.Send(request,Token);
        return response;

    }

}
