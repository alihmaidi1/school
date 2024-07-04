using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using infrastructure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Shared.CQRS;
using Shared.OperationResult;

namespace Admin.Student.Parent.Command.Delete;

public class DeleteParentHandler : OperationResult ,ICommandHandler<DeleteParentCommand>
{

    private ApplicationDbContext _context;

    public DeleteParentHandler(ApplicationDbContext context){

        _context=context;

    }
    public async Task<JsonResult> Handle(DeleteParentCommand request, CancellationToken cancellationToken)
    {

        await _context.Parents.Where(x=>x.Id==request.Id).ExecuteDeleteAsync(cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);
        await _context.AccountSessions.Where(x=>x.AccountId==request.Id).ExecuteDeleteAsync(cancellationToken);
        return Success("parent was deleted successfully");
    }
}
