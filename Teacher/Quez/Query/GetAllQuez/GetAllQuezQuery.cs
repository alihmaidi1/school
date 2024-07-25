using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bogus.DataSets;
using Common.CQRS;
using Shared.Abstraction;

namespace Teacher.Quez.Query.GetAllQuez;

public class GetAllQuezQuery: PaginationRequest, IQuery
{


    public Guid? YearId{get;set;}
    





}
