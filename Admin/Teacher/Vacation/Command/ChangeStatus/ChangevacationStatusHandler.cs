using System.Security.Claims;
using Admin.Teacher.Vacation.Command.Add;
using Common.CQRS;
using Domain.Entities.Manager.Admin;
using Domain.Entities.Teacher.Vacation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Repository.Teacher.Vacation;
using Shared.CQRS;
using Shared.OperationResult;

namespace Admin.Teacher.Vacation.Command.ChangeStatus;

public class ChangevacationStatusHandler:OperationResult,
    ICommandHandler<ChnageVacationStatusCommand>
{

    public IVacationRepository VacationRepository;

    private IHttpContextAccessor httpContextAccessor;
    public ChangevacationStatusHandler(IVacationRepository VacationRepository,IHttpContextAccessor httpContextAccessor)
    {

        this.httpContextAccessor = httpContextAccessor;
        this.VacationRepository = VacationRepository;

    }
    
    public async Task<JsonResult> Handle(ChnageVacationStatusCommand request, CancellationToken cancellationToken)
    {

        // var adminId = httpContextAccessor.HttpContext.User.Claims
        //     .FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier).Value;
        //
        // VacationRepository.ChangeStatus(new VacationID(request.Id), new AdminID(new Guid(adminId)), request.Status);
        //
        // // send notification to teacher
        // return Success("status was updated successfully");


        return null;
    }
}