using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Common.CQRS;
using Shared.Abstraction;

namespace Admin.ClassRoom.Subject.Query.GetSession;

public class GetSessionQuery: PaginationRequest,IQuery
{
    public Guid? YearId{get;set;}

    public Guid SubjectId{get;set;}

}
