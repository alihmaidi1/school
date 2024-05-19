using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Common.CQRS;
using Shared.Abstraction;

namespace Teacher.Quez.Query.GetAll;

public class GetAllTeacherQuezQuery: PaginationRequest, IQuery
{

    public Guid YearId{get;set;}

}
