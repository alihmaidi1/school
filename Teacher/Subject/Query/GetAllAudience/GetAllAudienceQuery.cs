using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Common.CQRS;

namespace Teacher.Subject.Query.GetAllAudience;

public class GetAllAudienceQuery: IQuery
{

    public Guid SubjectId{get;set;}

    public Guid YearId{get;set;}


}
