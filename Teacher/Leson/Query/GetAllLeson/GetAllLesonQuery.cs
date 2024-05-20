using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Common.CQRS;
using Shared.Abstraction;

namespace Teacher.Leson.Teacher.Leson.Query.GetAllLeson;

public class GetAllLesonQuery: IQuery
{



    public Guid YearId{get;set;}




}
