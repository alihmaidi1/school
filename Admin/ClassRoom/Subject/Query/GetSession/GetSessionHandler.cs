using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Common.CQRS;
using infrastructure;
using Microsoft.AspNetCore.Mvc;
using Shared.OperationResult;

namespace Admin.ClassRoom.Subject.Query.GetSession;

public class GetSessionHandler : OperationResult,IQueryHandler<GetSessionQuery>
{

    private ApplicationDbContext _context;
    public GetSessionHandler(ApplicationDbContext context){

        _context=context;

    }

    public async Task<JsonResult> Handle(GetSessionQuery request, CancellationToken cancellationToken)
    {

        var SessionNumber=_context
        .SubjectYears
        .Where(x=>x.SubjectId==request.SubjectId)
        .Where(x=>x.ClassYear.YearId==request.YearId)
        .SelectMany(x=>x.Audiences)
        .Select(x=>x.SessionNumber)
        .Distinct()
        .ToList();

        return Success(SessionNumber,"this is your session number");
    }
}
