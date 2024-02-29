using Common.CQRS;

namespace Admin.Manager.Role.Query.Get;

public class GetManagerByRoleQuery:IQuery
{
    
    
    public Guid Id { get; set; }

    public string? OrderBy { get; set; }

    public int? PageNumber { get; set; }

    public int? PageSize { get; set; }
}