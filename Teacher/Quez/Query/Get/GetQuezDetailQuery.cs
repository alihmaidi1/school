using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Common.CQRS;

namespace Teacher.Quez.Query.Get;

public class GetQuezDetailQuery: IQuery
{

    public Guid Id{get;set;}

}
