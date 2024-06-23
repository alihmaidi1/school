using System.Security.Claims;
using Admin.Teacher.Vacation.Command.Add;
using Common.CQRS;
using Domain.Entities.Manager.Admin;
using Domain.Entities.Teacher.Vacation;
using infrastructure;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using Repository.Teacher.Vacation;
using Shared.CQRS;
using Shared.OperationResult;
using Shared.Services.User;

namespace Admin.Teacher.Vacation.Command.ChangeStatus;

public class ChangevacationStatusHandler:OperationResult,ICommandHandler<ChnageVacationStatusCommand>
{

    private ApplicationDbContext _context;    
    private ICurrentUserService _currentUserService;
    public ChangevacationStatusHandler(ApplicationDbContext context,ICurrentUserService currentUserService)
    {

        _context=context;
        _currentUserService=currentUserService;

    }
    
    public async Task<JsonResult> Handle(ChnageVacationStatusCommand request, CancellationToken cancellationToken)
    {

        await _context.Vacations.Where(x=>x.Id==request.Id).ExecuteUpdateAsync(setter=>setter.SetProperty(x=>x.Status,request.Status).SetProperty(x=>x.AdminId,_currentUserService.GetUserid()),cancellationToken);
        return Success("status was updated successfully");


    }
}