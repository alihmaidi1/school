using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Common.CQRS;

namespace Admin.ClassRoom.Subject.Query.GetActive;

public class GetActiveSubjectQuery: IQuery
{



    public Guid Id{get;set;}

}
