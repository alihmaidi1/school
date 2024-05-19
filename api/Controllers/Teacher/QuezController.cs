using Domain.Dto.Quez;
using Dto.Admin.Teacher;
using Dto.Quez;
using infrastructure.Attribute;
using Microsoft.AspNetCore.Mvc;
using schoolManagement.Base;
using Shared.Entity.EntityOperation;
using Shared.OperationResult.Base;
using Shared.Swagger;
using Teacher.Quez.Command.Add;
using Teacher.Quez.Command.Delete;
using Teacher.Quez.Command.Update;
using Teacher.Quez.Query.Get;
using Teacher.Quez.Query.GetAll;
using Teacher.Quez.Query.GetStudentAnswer;

namespace schoolmanagment.Controllers.Teacher;

[ApiGroup(ApiGroupName.All, ApiGroupName.Teacher)]
[Microsoft.AspNetCore.Mvc.Route("Api/Teacher/[controller]/[action]")]
[CheckTokenSession()]

public class QuezController:ApiController
{

        /// <summary>
    /// Create a new quez to specific subject in currect year
    /// </summary>
    [Produces(typeof(OperationResultBase<Boolean>))]
    [HttpPost]
    public async Task<IActionResult> Add([FromForm] AddQuezCommand command,CancellationToken token)
    {
        var response = await this.Mediator.Send(command,token);
        return response;

    }


            /// <summary>
    /// Delete a  Quez from specific subject 
    /// </summary>
    [Produces(typeof(OperationResultBase<Boolean>))]
    [HttpDelete]
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
    public async Task<IActionResult> Update([FromForm] UpdateQuezCommand command,CancellationToken token)
    {
        var response = await this.Mediator.Send(command,token);
        return response;

    }

    /// <summary>
    /// Get All   Quez this year 
    /// </summary>
    [Produces(typeof(OperationResultBase<PageList<GetAllTeacherQuezDto>>))]
    [HttpGet]
    public async Task<IActionResult> GetAll([FromQuery] GetAllTeacherQuezQuery command,CancellationToken token)
    {
        var response = await this.Mediator.Send(command,token);
        return response;

    }


    /// <summary>
    /// Get  Quez detail  
    /// </summary>
    [Produces(typeof(OperationResultBase<GetFinishQuezDetailDto>))]
    [HttpGet]
    public async Task<IActionResult> GetFinishQuezDetail([FromQuery] GetQuezDetailQuery command,CancellationToken token)
    {
        var response = await this.Mediator.Send(command,token);
        return response;

    }


    /// <summary>
    /// Get Student Answer Detail  
    /// </summary>
    [Produces(typeof(OperationResultBase<StudentAnswerDto>))]
    [HttpGet]
    public async Task<IActionResult> GetStudentAnswer([FromQuery] GetStudentAnswerQuery command,CancellationToken token)
    {
        var response = await this.Mediator.Send(command,token);
        return response;

    }


}
