using Common.CQRS;
using Repository.Manager.Admin;
using Shared.Abstraction;

namespace Admin.Manager.Admin.Query.GetAll;

public class GetAllAdminQuery: PaginationRequest , IQuery
{
    public AdminSorting.OrderBy OrderBy { get; set; }
    public string? Search { get; set; }

}