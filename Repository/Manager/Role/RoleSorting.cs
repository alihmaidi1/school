using System.Linq.Expressions;

namespace Repository.Manager.Role;

public static class RoleSorting
{
    public static List<string> OrderBy = new()
    {
        "Name",
        "DateCreated"
    };


    public static Func<string, Expression<Func<Domain.Entities.Role.Role, object>>> switchOrdering = key
        => key switch
        {
            "Name" => x => x.Name,
            _ => x => x.DateCreated
        };
}