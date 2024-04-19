using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace Shared.Entity.EntityOperation.BulkMerge;

public static class EntityFrameworkHelper
{

    public static string GetTableName<T>(DbSet<T> dbSet) where T : class
    {
        
        var context = dbSet.GetService<ICurrentDbContext>().Context;
        var entityType = context.Model.FindEntityType(typeof(T));
        var tableName = entityType?.GetTableName()?? throw new Exception("can not get table name");
        return tableName;

    }


    public static bool HasPrimaryKey<T>(DbSet<T> dbset) where T: class
    {
        
        var context = dbset.GetService<ICurrentDbContext>().Context;
        var entityType = context.Model.FindEntityType(typeof(T))?? throw new Exception("entity type is not exists in dbContext");
        var primaryKey = entityType.FindPrimaryKey()?? throw new Exception($"entity {typeof(T).ToString()} does not have any primary key");
        var hasIdentityPrimaryKey = primaryKey.Properties.Count == 1 && primaryKey.Properties[0].ValueGenerated == Microsoft.EntityFrameworkCore.Metadata.ValueGenerated.OnAdd;
        return hasIdentityPrimaryKey;
    }
}