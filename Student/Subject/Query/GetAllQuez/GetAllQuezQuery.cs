using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Common.CQRS;
using Shared.Abstraction;

namespace Student.Subject.Query.GetAllQuez;

public class GetAllQuezQuery:PaginationRequest,IQuery
{


    public string? Search{get;set;}

    public Guid SubjectYearId{get;set;}

}
