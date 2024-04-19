using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using infrastructure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Shared.CQRS;
using Shared.OperationResult;

namespace Teacher.Leson.Command.Delete;

public class DeleteLesonHandler : OperationResult, ICommandHandler<deleteLesonCommand>
{

    private readonly ApplicationDbContext _context;
    public DeleteLesonHandler(ApplicationDbContext context){

        _context=context;

    }
    public async Task<JsonResult> Handle(deleteLesonCommand request, CancellationToken cancellationToken)
    {

        await _context.Lesons.Where(x=>x.Id==request.Id).ExecuteUpdateAsync(setter=>setter.SetProperty(x=>x.DateDeleted,DateTime.Now),cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);

        return Success("leson was deleted successfully");
    }
}
