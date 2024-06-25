using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Common.CQRS;

namespace Student.Quez.Query.GetFinishQuezInfo;

public class GetFinishQuezInfoQuery:IQuery
{
    public Guid StudentQuezId{get;set;}

}
