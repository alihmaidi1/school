using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using infrastructure.Attribute;
using Microsoft.AspNetCore.Mvc;
using schoolManagement.Base;
using Shared.OperationResult.Base;
using Shared.Swagger;
using Teacher.Question.Command.Add;
using Teacher.Question.Command.Delete;
using Teacher.Question.Command.Update;
using Teacher.Quez.Command.Delete;

namespace schoolmanagment.Controllers.Teacher;

[ApiGroup(ApiGroupName.All, ApiGroupName.Teacher)]
[Microsoft.AspNetCore.Mvc.Route("Api/Teacher/[controller]/[action]")]
[CheckTokenSession()]

public class QuestionController: ApiController
{
        /// <summary>
    /// Create a new question to specific quez in currect year
    /// </summary>
    [Produces(typeof(OperationResultBase<Boolean>))]
    [HttpPost]
    public async Task<IActionResult> Add([FromForm] AddQuestionCommand command,CancellationToken token)
    {
        var response = await this.Mediator.Send(command,token);
        return response;

    }


    /// <summary>
    /// Delete a  question from specific quez 
    /// </summary>
    [Produces(typeof(OperationResultBase<Boolean>))]
    [HttpDelete]
    public async Task<IActionResult> Delete([FromQuery] DeleteQuestionCommand command,CancellationToken token)
    {
        var response = await this.Mediator.Send(command,token);
        return response;

    }


    /// <summary>
    /// Update a  question To specific quez 
    /// </summary>
    [Produces(typeof(OperationResultBase<Boolean>))]
    [HttpPut]
    public async Task<IActionResult> Update([FromForm] UpdateQuestionCommand command,CancellationToken token)
    {
        var response = await this.Mediator.Send(command,token);
        return response;

    }



}
