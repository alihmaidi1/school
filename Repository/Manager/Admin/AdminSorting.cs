using System.Linq.Expressions;

namespace Repository.Manager.Admin;

public static class AdminSorting
{
    // public static List<string> OrderBy = new()
    // {
    //     "Name",
    //     "Email",
    //     "DateCreated"
    // };

    public enum OrderBy
    {
        Name=1,
        Email,
        DateCreated
        
    }
    

    public static readonly Func<OrderBy, Expression<Func<Domain.Entities.Manager.Admin.Admin, object>>> SwitchOrdering = key
        => key switch
        {
            OrderBy.Name => x => x.Name,
            OrderBy.Email => x => x.Email,
            _ => x => x.DateCreated
        };
}