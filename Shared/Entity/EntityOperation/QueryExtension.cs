using System.Linq.Expressions;

namespace Shared.Entity.EntityOperation;

public static class QueryExtension
{
    public static IOrderedQueryable<T> SortThenBy<T, Tkey>(this IOrderedQueryable<T> source,
        Expression<Func<T, Tkey>> by, bool? isDes = false)
    {
        return !isDes.HasValue || isDes.Value
            ? source?.ThenByDescending(by)
            : source?.ThenBy(by);
    }

    public static IOrderedQueryable<T> SortBy<T, Tkey>(this IQueryable<T> source, Expression<Func<T, Tkey>> by,
        bool? isDes = false)
    {
        return !isDes.HasValue || isDes.Value
            ? source?.OrderByDescending(by)
            : source?.OrderBy(by);
    }
}