using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Common.CQRS;

namespace Admin.Parent.Query;
public class GetAllChildBillQuery: IQuery
{

    public Guid ParentId{get;set;}

}
