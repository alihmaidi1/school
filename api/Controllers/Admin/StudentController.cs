using Admin.ClassRoom.Student.Query.GetByStage;
using Admin.ClassRoom.Student.Query.GetSubjectByYear;
using Admin.Student.Student.Command.Add;
using Admin.Student.Student.Command.Delete;
using Admin.Student.Student.Command.PayBill;
using Admin.Student.Student.Query.GetAll;
using Admin.Student.Student.Query.GetAllInstallment;
using Admin.Student.Student.Query.GetAllQuezByYearAndSubject;
using Admin.Student.Student.Query.GetAllStudentBill;
using Domain.Dto.Student;
using Domain.Enum;
using Dto.Student.Student;
using infrastructure.Attribute;
using Microsoft.AspNetCore.Mvc;
using schoolManagement.Base;
using Shared.Entity.EntityOperation;
using Shared.OperationResult.Base;
using Shared.Swagger;

namespace schoolmanagment.Controllers.Admin;


[Microsoft.AspNetCore.Mvc.Route("Api/SuperAdmin/[controller]/[action]")]
[ApiGroup(ApiGroupName.All, ApiGroupName.Admin)]
[CheckTokenSession(Policy = nameof(PermissionEnum.Student))]

public class StudentController: ApiController
{

    // /// <summary>
    // /// get all student in stage 
    // /// </summary>
    // /// <returns>return all role in pagination</returns>
    // [Produces(typeof(OperationResultBase<PageList<GetAllStudentStageDto>>))]
   
    // [HttpGet]
    // public async Task<IActionResult> GetAllStudentByStage([FromQuery] GetStudentByStageQuery request,CancellationToken Token)
    // {
    //     var response = await this.Mediator.Send(request,Token);
    //     return response;

    // }


    /// <summary>
    /// Add a New Student In School 
    /// </summary>
    /// <returns>return all role in pagination</returns>
    [Produces(typeof(OperationResultBase<Boolean>))]
   
    [HttpPost]
    public async Task<IActionResult> Add([FromBody] AddStudentCommand request,CancellationToken Token)
    {
        var response = await this.Mediator.Send(request,Token);
        return response;

    }



    /// <summary>
    /// Delete Student from School 
    /// </summary>
    /// <returns>return all role in pagination</returns>
    [Produces(typeof(OperationResultBase<Boolean>))]
   
    [HttpDelete]
    public async Task<IActionResult> Delete([FromQuery] DeleteStudentCommand request,CancellationToken Token)
    {
        var response = await this.Mediator.Send(request,Token);
        return response;

    }

    /// <summary>
    /// get all student mark in specifice year 
    /// </summary>
    /// <returns>return all role in pagination</returns>
    [Produces(typeof(OperationResultBase<List<GetAllStudentSubjectDto>>))]

    [HttpGet]
    public async Task<IActionResult> GetAllStudentSubjectByYear([FromQuery] GetStudentSubjectByYearQuery request,CancellationToken Token)
    {
        var response = await this.Mediator.Send(request,Token);
        return response;

    }



    /// <summary>
    /// get all student quez in specifice year 
    /// </summary>
    /// <returns>return all role in pagination</returns>
    [Produces(typeof(OperationResultBase<List<Dto.Student.Student.GetAllStudentQuezDto>>))]

    [HttpGet]
    public async Task<IActionResult> GetAllStudentQuezByYearAndSubject([FromQuery] GetAllQuezByYearAndSubjectQuery request,CancellationToken Token)
    {
        var response = await this.Mediator.Send(request,Token);
        return response;

    }


    /// <summary>
    /// get all student  
    /// </summary>
    /// <returns>return all role in pagination</returns>
    [Produces(typeof(OperationResultBase<PageList<GetAllStudentStageDto>>))]

    [HttpGet]
    public async Task<IActionResult> GetAll([FromQuery] GetAllStudentQuery request,CancellationToken Token)
    {
        var response = await this.Mediator.Send(request,Token);
        return response;

    }


    /// <summary>
    /// get all student installment  
    /// </summary>
    /// <returns>return all role in pagination</returns>
    [Produces(typeof(OperationResultBase<List<GetAllInstallmentDto>>))]

    [HttpGet]
    public async Task<IActionResult> GetAllInstallment([FromQuery] GetAllInstallmentQuery request,CancellationToken Token)
    {
        var response = await this.Mediator.Send(request,Token);
        return response;

    }


    /// <summary>
    /// get all student Bill in specific year  
    /// </summary>
    /// <returns>return all role in pagination</returns>
    [Produces(typeof(OperationResultBase<GetAllStudentBillDto>))]

    [HttpGet]
    public async Task<IActionResult> GetAllStudentBill([FromQuery] GetAllStudentBillQuery request,CancellationToken Token)
    {
        var response = await this.Mediator.Send(request,Token);
        return response;

    }



    /// <summary>
    /// Pay Bill  
    /// </summary>
    /// <returns>return all role in pagination</returns>
    [Produces(typeof(OperationResultBase<Boolean>))]
    [HttpPost]
    public async Task<IActionResult> PayBill([FromBody] PayBillCommand request,CancellationToken Token)
    {
        var response = await this.Mediator.Send(request,Token);
        return response;

    }
}
