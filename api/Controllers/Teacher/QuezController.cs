using Domain.Dto.Quez;
using Domain.Enum;
using Dto.Admin.Teacher;
using Dto.Quez;
using infrastructure.Attribute;
using Microsoft.AspNetCore.Mvc;
using schoolManagement.Base;
using Shared.Entity.EntityOperation;
using Shared.Enum;
using Shared.OperationResult.Base;
using Shared.Swagger;
using Teacher.Quez.Command.Add;
using Teacher.Quez.Command.Delete;
using Teacher.Quez.Command.Update;
using Teacher.Quez.Query.Get;
using Teacher.Quez.Query.GetAll;
using Teacher.Quez.Query.GetAllQuez;
using Teacher.Quez.Query.GetAllQuezWithQuestionAndAnswer;
using Teacher.Quez.Query.GetQuestion;
using Teacher.Quez.Query.GetStudentAnswer;

namespace schoolmanagment.Controllers.Teacher;

[ApiGroup(ApiGroupName.All, ApiGroupName.Teacher)]
[Microsoft.AspNetCore.Mvc.Route("Api/Teacher/[controller]/[action]")]


public class QuezController:ApiController
{

        /// <summary>
    /// Create a new quez to specific subject in currect year
    /// </summary>
    [Produces(typeof(OperationResultBase<Boolean>))]
    [HttpPost]
    [CheckTokenSession(AuthenticationSchemes =nameof(JwtSchema.Teacher))]
    [CheckTokenSession(AuthenticationSchemes =nameof(JwtSchema.Admin),Policy =nameof(PermissionEnum.Quez))]

    public async Task<IActionResult> Add([FromBody] AddQuezCommand command,CancellationToken token)
    {
        var response = await this.Mediator.Send(command,token);
        return response;

    }


            /// <summary>
    /// Delete a  Quez from specific subject 
    /// </summary>
    [Produces(typeof(OperationResultBase<Boolean>))]
    [HttpDelete]
    
    [CheckTokenSession(AuthenticationSchemes =nameof(JwtSchema.Teacher))]
    [CheckTokenSession(AuthenticationSchemes =nameof(JwtSchema.Admin),Policy =nameof(PermissionEnum.Quez))]

    public async Task<IActionResult> Delete([FromQuery] DeleteQuezCommand command,CancellationToken token)
    {
        var response = await this.Mediator.Send(command,token);
        return response;

    }


    /// <summary>
    /// Update a  Quez To specific subject 
    /// </summary>
    [Produces(typeof(OperationResultBase<Boolean>))]
    [HttpPut]
    [CheckTokenSession(AuthenticationSchemes =nameof(JwtSchema.Teacher))]

    public async Task<IActionResult> Update([FromForm] UpdateQuezCommand command,CancellationToken token)
    {
        var response = await this.Mediator.Send(command,token);
        return response;

    }

    /// <summary>
    /// Get All  Quez in specific year 
    /// </summary>
    [Produces(typeof(OperationResultBase<PageList<GetAllTeacherQuezDto>>))]
    [HttpGet]
    [CheckTokenSession(AuthenticationSchemes =nameof(JwtSchema.Teacher))]

    public async Task<IActionResult> GetAll([FromQuery] GetAllQuezQuery command,CancellationToken token)
    {
        var response = await this.Mediator.Send(command,token);
        return response;

    }


    /// <summary>
    /// Get  Quez detail  
    /// </summary>
    [Produces(typeof(OperationResultBase<GetFinishQuezDetailDto>))]
    [HttpGet]
    [CheckTokenSession(AuthenticationSchemes =nameof(JwtSchema.Teacher))]

    public async Task<IActionResult> GetQuezDetail([FromQuery] GetQuezDetailQuery command,CancellationToken token)
    {
        var response = await this.Mediator.Send(command,token);
        return response;

    }


    /// <summary>
    /// Get Student Answer Detail  
    /// </summary>
    [Produces(typeof(OperationResultBase<StudentAnswerDto>))]
    [HttpGet]
     [CheckTokenSession(AuthenticationSchemes =nameof(JwtSchema.Teacher))]
    [CheckTokenSession(AuthenticationSchemes =nameof(JwtSchema.Admin),Policy = nameof(PermissionEnum.Quez))]

    public async Task<IActionResult> GetStudentAnswer([FromQuery] GetStudentAnswerQuery command,CancellationToken token)
    {
        var response = await this.Mediator.Send(command,token);
        return response;

    }


    /// <summary>
    /// Get Quez With Question Detail  
    /// </summary>
    [Produces(typeof(OperationResultBase<PageList<GetQuezQuestionDetailDto>>))]
    [HttpGet]
    [CheckTokenSession(AuthenticationSchemes =nameof(JwtSchema.Teacher))]

    public async Task<IActionResult> GetQuestion([FromQuery] GetQuezQuestionQuery command,CancellationToken token)
    {
        var response = await this.Mediator.Send(command,token);
        return response;

    }


    /// <summary>
    /// Get Quez With Question Detail and Answer  
    /// </summary>
    [Produces(typeof(OperationResultBase<GetQuezwithQuestionAndDetailDto>))]
    [HttpGet]
    [CheckTokenSession(AuthenticationSchemes =nameof(JwtSchema.Teacher))]
    [CheckTokenSession(AuthenticationSchemes =nameof(JwtSchema.Admin),Policy = nameof(PermissionEnum.Quez))]

    public async Task<IActionResult> GetQuezDetailWithQuestionAndAnswer([FromQuery] GetQuezWithQuestionAndAnswerQuery command,CancellationToken token)
    {
        var response = await this.Mediator.Send(command,token);
        return response;

    }

}
