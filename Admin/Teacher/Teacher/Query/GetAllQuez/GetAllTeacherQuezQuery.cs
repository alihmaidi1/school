using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bogus.DataSets;
using Common.CQRS;

namespace Admin.Teacher.Teacher.Query.GetAllQuez;

public class GetAllTeacherQuezQuery: IQuery
{

    public Guid Id {get;set;} 

    public Guid YearId{get;set;}
    


    
    public int? PageNumber { get; set; }
    
    public int? PageSize { get; set; }

    public string? Search{get;set;}   



}
