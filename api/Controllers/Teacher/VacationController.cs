using Admin.Teacher.Vacation.Command.Add;
using Domain.AppMetaData.Teacher;
using Microsoft.AspNetCore.Mvc;
using schoolManagement.Base;
using Shared.Swagger;

namespace schoolmanagment.Controllers.Teacher;


[ApiGroup(ApiGroupName.All, ApiGroupName.Teacher)]

public class VacationController:ApiController
{
    
    [HttpPost(VacationRouter.prefix)]
    public async Task<IActionResult> GetAllTeacher([FromBody] AddVacationCommand request,CancellationToken Token)
    {
        var response = await this.Mediator.Send(request,Token);
        return response;

    }

    
}