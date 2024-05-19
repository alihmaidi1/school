using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Common.CQRS;

namespace Teacher.Subject.Query.GetAudienceDetail;

public class GetAudienceDetailQuery: IQuery
{

    public Guid SubjectId{get;set;}
    public DateTime Date{get;set;}
    
}
