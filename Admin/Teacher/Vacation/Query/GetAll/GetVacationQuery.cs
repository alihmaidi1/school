using Common.CQRS;

namespace Admin.Teacher.Vacation.Query.GetAll;

public class GetVacationQuery:IQuery
{
    
    public int? PageNumber { get; set; }
    
    public int? PageSize { get; set; }
    public Guid? TeacherId { get; set; }
    
    public bool? Status { get; set;}
    
}