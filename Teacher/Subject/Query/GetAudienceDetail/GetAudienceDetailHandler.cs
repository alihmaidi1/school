using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Common.CQRS;
using Domain.Dto.ClassRoom;
using infrastructure;
using Microsoft.AspNetCore.Mvc;
using Shared.OperationResult;

namespace Teacher.Subject.Query.GetAudienceDetail;

public class GetAudienceDetailHandler : OperationResult, IQueryHandler<GetAudienceDetailQuery>
{

    private ApplicationDbContext _context;
    public GetAudienceDetailHandler(ApplicationDbContext context){

        _context=context;
    }
    public async Task<JsonResult> Handle(GetAudienceDetailQuery request, CancellationToken cancellationToken)
    {

        var Students=_context
        .SubjectYears
        .Where(x=>x.SubjectId==request.SubjectId)
        .SelectMany(x=>x.Audiences.Where(x=>x.Date==request.Date))
        .Select(x=>new GetAudienceDetailDto{

            Id=x.Student.Id,
            Name=x.Student.Name,
            Status=x.IsExists
        })
        .ToList();

        return Success(Students,"this is your info");
    }
}
