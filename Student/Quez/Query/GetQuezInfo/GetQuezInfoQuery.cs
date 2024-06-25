using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Common.CQRS;

namespace Student.Quez.Query.GetQuezInfo;

public class GetQuezInfoQuery: IQuery
{

    public Guid Id{get;set;}

}
