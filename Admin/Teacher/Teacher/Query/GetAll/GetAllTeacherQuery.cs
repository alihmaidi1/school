using Common.CQRS;

namespace Admin.Teacher.Teacher.Query.GetAll;

public class GetAllTeacherQuery:IQuery
{
    
    
    public string? OrderBy { get; set; }
    
    public int? PageNumber { get; set; }
    
    public int? PageSize { get; set; }


}