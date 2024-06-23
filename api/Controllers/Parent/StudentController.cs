using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Dto.Parent;
using Domain.Dto.Quez;
using Domain.Dto.Student;
using infrastructure.Attribute;
using Microsoft.AspNetCore.Mvc;
using Parent.Student.Command.GiveReasonOfAudience;
using Parent.Student.Query.FinalResult;
using Parent.Student.Query.GetAllAudience;
using Parent.Student.Query.GetAllName;
using Parent.Student.Query.GetBill;
using Parent.Student.Query.GetStudentMarks;
using schoolManagement.Base;
using Shared.Entity.EntityOperation;
using Shared.Enum;
using Shared.OperationResult.Base;
using Shared.Swagger;

namespace schoolmanagment.Controllers.Parent;


[ApiGroup(ApiGroupName.All, ApiGroupName.Parent)]

[Route("Api/Parent/[controller]/[action]")]

[CheckTokenSession(AuthenticationSchemes =nameof(JwtSchema.Parent))]

public class StudentController: ApiController
{


        /// <summary>
    /// Get All Parent Student
    /// </summary>
    [HttpGet]
    [Produces(typeof(OperationResultBase<List<GetAllStudentNameDto>>))]

    public async Task<IActionResult> GetAllNotification([FromQuery] GetAllChildNameQuery command,CancellationToken Token)
    {
        var response = await this.Mediator.Send(command,Token);
        return response;

    }



    /// <summary>
    /// Get Student Final Result
    /// </summary>
    [HttpGet]
    [Produces(typeof(OperationResultBase<GetAllStudentResultDto>))]

    public async Task<IActionResult> GetFinalResults([FromQuery] GetParentFinalResultQuery command,CancellationToken Token)
    {
        var response = await this.Mediator.Send(command,Token);
        return response;

    }



    /// <summary>
    /// Get Student Bill
    /// </summary>
    [HttpGet]
    [Produces(typeof(OperationResultBase<PageList<GetAllParentBillDto>>))]

    public async Task<IActionResult> GetParentBill([FromQuery] GetParentBillQuery command,CancellationToken Token)
    {
        var response = await this.Mediator.Send(command,Token);
        return response;

    }


    /// <summary>
    /// Get Student Audiences
    /// </summary>
    [HttpGet]
    [Produces(typeof(OperationResultBase<PageList<GetAllParentStudentAudienceDto>>))]

    public async Task<IActionResult> GetAllStudentAudiences([FromQuery] GetAllParentAudienceQuery command,CancellationToken Token)
    {
        var response = await this.Mediator.Send(command,Token);
        return response;

    }

    /// <summary>
    /// Give  Audience Reason 
    /// </summary>
    [HttpPut]
    [Produces(typeof(OperationResultBase<Boolean>))]

    public async Task<IActionResult> GiveAudienceReason([FromQuery] GiveReasonOfAudienceCommand command,CancellationToken Token)
    {
        var response = await this.Mediator.Send(command,Token);
        return response;

    }



    /// <summary>
    /// Get All Student quez 
    /// </summary>
    [HttpGet]
    [Produces(typeof(OperationResultBase<PageList<GetParentStudentMarksDto>>))]

    public async Task<IActionResult> GetAllStudentQuezMark([FromQuery] GetParentStudentMarksQuery command,CancellationToken Token)
    {
        var response = await this.Mediator.Send(command,Token);
        return response;

    }



}
