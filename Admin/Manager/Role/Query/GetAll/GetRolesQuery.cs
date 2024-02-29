using Common.CQRS;

namespace Admin.Manager.Role.Query.GetAll;

public  class GetRolesQuery:IQuery
{
    
    public string? OrderBy { get; set; }

    public int? PageNumber { get; set; }

    public int? PageSize { get; set; }
}