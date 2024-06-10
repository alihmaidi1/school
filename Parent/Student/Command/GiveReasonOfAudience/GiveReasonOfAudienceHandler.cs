using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Threading.Tasks;
using infrastructure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Shared.CQRS;
using Shared.OperationResult;

namespace Parent.Student.Command.GiveReasonOfAudience;

public class GiveReasonOfAudienceHandler : OperationResult,ICommandHandler<GiveReasonOfAudienceCommand>
{

    private ApplicationDbContext _context;
    
    public GiveReasonOfAudienceHandler(ApplicationDbContext context){

        _context=context;
    }
    public async Task<JsonResult> Handle(GiveReasonOfAudienceCommand request, CancellationToken cancellationToken)
    {
        await _context
        .Audiences
        .Where(x=>x.Id==request.Id)
        .ExecuteUpdateAsync(setter=>setter.SetProperty(x=>x.Reason,request.Reason),cancellationToken);
        return Success("gived successfully");
    }
}
