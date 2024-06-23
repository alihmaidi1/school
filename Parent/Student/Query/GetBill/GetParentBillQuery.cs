using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Common.CQRS;
using Shared.Abstraction;

namespace Parent.Student.Query.GetBill;

public class GetParentBillQuery: IQuery
{


    public Guid StudentId{get;set;}

}
