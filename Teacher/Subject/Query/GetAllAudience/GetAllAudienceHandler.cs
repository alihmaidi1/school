using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Common.CQRS;
using infrastructure;
using Microsoft.AspNetCore.Mvc;
using Shared.OperationResult;

namespace Teacher.Subject.Query.GetAllAudience;

public class GetAllAudienceHandler : OperationResult, IQueryHandler<GetAllAudienceQuery>
{

    private ApplicationDbContext _context;

    public GetAllAudienceHandler(ApplicationDbContext context){

        _context=context;
    }
    public async Task<JsonResult> Handle(GetAllAudienceQuery request, CancellationToken cancellationToken)
    {

        // var Dates=_context
        // .SubjectYears
        // .Where(x=>x.SubjectId==request.SubjectId&&x.YearId==request.YearId)
        // .SelectMany(x=>x.Audiences)
        // .GroupBy(x=>x.SessionNumber)
        // .Select(x=>x.First())
        // .Select(x=>x.Date)
        // .ToList();

        // return Success(Dates,"this is all audience");
    
        return null;
    }
}
