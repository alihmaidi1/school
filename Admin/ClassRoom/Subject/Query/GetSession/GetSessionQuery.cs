using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Common.CQRS;

namespace Admin.ClassRoom.Subject.Query.GetSession;

public class GetSessionQuery: IQuery
{

    public Guid YearId{get;set;}

    public Guid SubjectId{get;set;}

}
