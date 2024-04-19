using Admin.Manager.Role.Command.Add;
using Admin.Teacher.Teacher.Command.Add;
using Admin.Teacher.Teacher.Command.Delete;
using Admin.Teacher.Teacher.Command.Update;
using Admin.Teacher.Teacher.Query.GetAll;
using Admin.Teacher.Teacher.Query.GetAllLeson;
using Admin.Teacher.Teacher.Query.GetAllQuez;
using Admin.Teacher.Teacher.Query.GetAllSubjectAndStudent;
using Domain.AppMetaData.Admin;
using Domain.Enum;
using Dto.Admin.Teacher;
using infrastructure.Attribute;
using Microsoft.AspNetCore.Mvc;
using schoolManagement.Base;
using Shared.Entity.EntityOperation;
using Shared.OperationResult.Base;
using Shared.Swagger;

namespace schoolmanagment.Controllers.Admin;


[Route("Api/SuperAdmin/[controller]/[action]")]
[ApiGroup(ApiGroupName.All, ApiGroupName.Admin)]
[CheckTokenSession(Policy = nameof(PermissionEnum.Admin))]
public class TeacherController:ApiController
{
    
    


    /// <summary>
    /// get all Teacher with subject count in this year 
    /// </summary>
    /// <returns>return all role in pagination</returns>
    [Produces(typeof(OperationResultBase<PageList<GetAllTeacher>>))]
   
    [HttpGet]
    public async Task<IActionResult> GetAllTeacher([FromQuery] GetAllTeacherQuery request,CancellationToken Token)
    {
        var response = await this.Mediator.Send(request,Token);
        return response;

    }



    /// <summary>
    /// get all Teacher with subject and student in all year 
    /// </summary>
    /// <returns>return all role in pagination</returns>
    [Produces(typeof(OperationResultBase<PageList<GetAllSubjectAndStudentDto>>))]
   
    [HttpGet]
    public async Task<IActionResult> GetAllSubjectWithStudent([FromQuery] GetAllSubjectAndStudentQuery request,CancellationToken Token)
    {
        var response = await this.Mediator.Send(request,Token);
        return response;

    }


    /// <summary>
    /// get all Teacher  subject  and leson  in specific year 
    /// </summary>
    /// <returns>return all role in pagination</returns>
    [Produces(typeof(OperationResultBase<PageList<GetAllSubjectAndStudentDto>>))]
   
    [HttpGet]
    public async Task<IActionResult> GetAllSubjectAndLeson([FromQuery] GetAllTeacherLesonQuery request,CancellationToken Token)
    {
        var response = await this.Mediator.Send(request,Token);
        return response;

    }



    /// <summary>
    /// get all Teacher  subject  and leson  in specific year 
    /// </summary>
    /// <returns>return all role in pagination</returns>
    [Produces(typeof(OperationResultBase<PageList<GetAllTeacherQuezDto>>))]
   
    [HttpGet]
    public async Task<IActionResult> GetAllTeacherQuez([FromQuery] GetAllTeacherQuezQuery request,CancellationToken Token)
    {
        var response = await this.Mediator.Send(request,Token);
        return response;

    }



 /// <summary>
    /// add new   Teacher and notify him by email 
    /// </summary>
    /// <returns>return if the operation successed</returns>
   
    [Produces(typeof(OperationResultBase<Boolean>))]
    [HttpPost]
    public async Task<IActionResult> AddTeacher([FromBody] AddTeacherCommand request,CancellationToken Token)
    {
        var response = await this.Mediator.Send(request,Token);
        return response;
    }


    /// <summary>
    /// update exists Teacher info and notify him by email 
    /// </summary>
    /// <returns>return if the operation successed</returns>
   
    
    [HttpDelete]
    public async Task<IActionResult> UpdateTeacher([FromBody] UpdateTeacherCommand request,CancellationToken Token)
    {
        var response = await this.Mediator.Send(request,Token);
        return response;
    }


    /// <summary>
    /// delete  Teacher  
    /// </summary>
    /// <returns>return if the operation successed</returns>
   
    
    [HttpPut]
    public async Task<IActionResult> DeleteTeacher(DeleteTeacherCommand request,CancellationToken Token)
    {
        var response = await this.Mediator.Send(request,Token);
        return response;
    }
}