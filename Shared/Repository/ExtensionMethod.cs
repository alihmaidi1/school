using System.Linq.Expressions;
using Common.Entity.Entity;
using Common.Entity.ValueObject;
using Shared.Entity.EntityOperation;

namespace Shared.Repository;

public static class ExtensionMethod
{
    public static IOrderedQueryable<T>? Sort<T>(this IQueryable<T> entity, string? sortType,
        Func<string, Expression<Func<T, object>>> switcher)  where T : BaseEntityWithoutId
    {
        if (sortType == null || sortType.Equals("")) return entity.OrderBy(x => x.DateCreated);

        var strings = sortType.Split(',').ToList();
        IOrderedQueryable<T>? OrderedData = null;
        foreach (var item in strings)
        {
            var isDes = item.StartsWith("-");
            var x = switcher(isDes ? item.Substring(1) : item);
            if (item.Equals(strings.First()))
                OrderedData = entity.SortBy(x, isDes);
            else
                OrderedData = OrderedData.SortThenBy(x, isDes);
        }

        return OrderedData;
    }
}