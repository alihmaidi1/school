using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using infrastructure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Shared.CQRS;
using Shared.OperationResult;

namespace Admin.Manager.Admin.Command.ChangeStatus;

public class ChnageAdminStatusHandler :OperationResult, ICommandHandler<ChangeAdminStatusCommand>
{

    ApplicationDbContext _context;

    public ChnageAdminStatusHandler(ApplicationDbContext context){

        _context=context;
    }

    public async Task<JsonResult> Handle(ChangeAdminStatusCommand request, CancellationToken cancellationToken)
    {
        
        await _context.Admins.Where(x=>x.Id==request.Id).ExecuteUpdateAsync(setter=>setter.SetProperty(x=>x.Status,request.Status),cancellationToken);
        return Success("admin status was updated successfully");
    }
}
