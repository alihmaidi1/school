using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Common.CQRS;

namespace Parent.Home.Query.GetHome;

public class GetHomeQuery: IQuery
{

    

    public List<Guid>? Childs{get;set;}

}
