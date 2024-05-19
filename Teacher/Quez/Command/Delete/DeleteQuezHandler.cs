using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using infrastructure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Shared.CQRS;
using Shared.OperationResult;

namespace Teacher.Quez.Command.Delete;

public class DeleteQuezHandler : OperationResult,ICommandHandler<DeleteQuezCommand>
{

    private readonly ApplicationDbContext _context;
    public DeleteQuezHandler(ApplicationDbContext context){

        _context=context;
    }
    public async Task<JsonResult> Handle(DeleteQuezCommand request, CancellationToken cancellationToken)
    {

        await _context.Quezs.Where(x=>x.Id==request.Id).ExecuteDeleteAsync(cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);
        return Success("quez deleted successfully");

    }
}
