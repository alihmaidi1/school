using System.Linq.Expressions;
using Domain.Enum.Ordering;

namespace Repository.Manager.Admin;

public static class AdminSorting
{


    public static readonly Func<AdminSortEnum, Expression<Func<Domain.Entities.Manager.Admin.Admin, object>>> SwitchOrdering = key
        => key switch
        {
            AdminSortEnum.Name => x => x.Name,
            AdminSortEnum.Email => x => x.Email,
            _ => x => x.DateCreated
        };
}