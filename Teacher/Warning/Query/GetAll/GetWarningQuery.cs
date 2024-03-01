using Common.CQRS;

namespace Teacher.Warning.Query.GetAll;

public class GetWarningQuery:IQuery
{
    
            
    public int? PageNumber { get; set; }
    
    public int? PageSize { get; set; }

}