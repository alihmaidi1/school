using Common.CQRS;
using Domain.Enum.Ordering;
using Repository.Manager.Admin;
using Shared.Abstraction;

namespace Admin.Manager.Admin.Query.GetAll;

public class GetAllAdminQuery: PaginationRequest , IQuery
{
    public string? Search { get; set; }

}