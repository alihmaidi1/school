using Common.CQRS;

namespace Admin.Teacher.Teacher.Query.GetAll;

public class GetAllTeacherQuery:IQuery
{
    
    
    
    public int? PageNumber { get; set; }
    
    public int? PageSize { get; set; }

    public string? Search{get;set;}

}