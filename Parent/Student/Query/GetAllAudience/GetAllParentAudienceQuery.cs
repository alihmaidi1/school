using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Common.CQRS;
using Shared.Abstraction;

namespace Parent.Student.Query.GetAllAudience;

public class GetAllParentAudienceQuery: PaginationRequest,IQuery
{

    public List<Guid>? Childs{get;set;}

}
