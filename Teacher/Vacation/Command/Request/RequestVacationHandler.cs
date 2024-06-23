using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities.Teacher.Vacation;
using infrastructure;
using Microsoft.AspNetCore.Mvc;
using Shared.CQRS;
using Shared.OperationResult;
using Shared.Services.User;

namespace Teacher.Vacation.Command.Request;

public class RequestVacationHandler : OperationResult, ICommandHandler<RequestVacationCommand>
{

    private ApplicationDbContext _context;
    private ICurrentUserService _currentUserService;
    public RequestVacationHandler(ApplicationDbContext context,ICurrentUserService currentUserService){

        _context=context;
        _currentUserService=currentUserService;
    }
    public async Task<JsonResult> Handle(RequestVacationCommand request, CancellationToken cancellationToken)
    {

        var Vacation=new Domain.Entities.Teacher.Vacation.Vacation(){

            Reason=request.Reason,
            Days=request.Period,            
            Date=request.StartAt,
            TeacherId=_currentUserService.GetUserid()!.Value,
            TypeId=request.TypeId


        };
        await _context.Vacations.AddAsync(Vacation);
        await _context.SaveChangesAsync(cancellationToken);

        return Success("vacation was sended to admin successfully");

    }
}
