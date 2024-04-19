using Common.CQRS;

namespace Admin.Student.Parent.Query.GetAll;

public class GetAllParentsQuery:IQuery 
{  

    
    public string? OrderBy { get; set; }
    
    public int? PageNumber { get; set; }
    
    public int? PageSize { get; set; }

    
    
    
}