using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities.Teacher.Teacher;
using infrastructure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Shared.CQRS;
using Shared.OperationResult;

namespace Admin.Teacher.Teacher.Command.ChangeStatus;

public class ChangeTeacherStatusHandler :OperationResult, ICommandHandler<ChangeTeacherStatusCommand>
{

    private ApplicationDbContext _context;

    public ChangeTeacherStatusHandler(ApplicationDbContext context){

        _context=context;

    }
    public async Task<JsonResult> Handle(ChangeTeacherStatusCommand request, CancellationToken cancellationToken)
    {
        _context.Teachers.Where(x=>x.Id==request.Id).ExecuteUpdate(setter=>setter.SetProperty(x=>x.Status,request.Status).SetProperty(x=>x.Reason,request.Status?null:request.Reason));
        
        return Success("teacher status was updated successfully");
    }
}
