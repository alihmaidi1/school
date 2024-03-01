using Common.CQRS;

namespace Admin.Teacher.Warning.Query.GetAll;

public class GetAllWarningAdminQuery:IQuery, ICommand
{
    
    public int? PageNumber { get; set; }
    
    public int? PageSize { get; set; }
    public Guid? TeacherId { get; set; }
    
    public int Date { get; set; }

    
}