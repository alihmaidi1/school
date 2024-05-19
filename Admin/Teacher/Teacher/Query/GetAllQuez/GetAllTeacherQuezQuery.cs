using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bogus.DataSets;
using Common.CQRS;
using Shared.Abstraction;

namespace Admin.Teacher.Teacher.Query.GetAllQuez;

public class GetAllTeacherQuezQuery: PaginationRequest, IQuery
{

    public Guid Id {get;set;} 

    public Guid YearId{get;set;}
    



    public string? Search{get;set;}   



}
