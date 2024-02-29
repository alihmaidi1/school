using Common.CQRS;

namespace Admin.Admin.Query.GetAll;

public class GetAllAdminQuery:IQuery
{
    public string? OrderBy { get; set; }

    public int? PageNumber { get; set; }

    public int? PageSize { get; set; }
}