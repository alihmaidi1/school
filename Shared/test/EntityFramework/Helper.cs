using System.Data;
using System.Reflection;
using EntityFramework.BulkExtension.DataBases.Upsert;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;

namespace EntityFramework.BulkExtension.EntityFramework;

public class Helper
{
    
    public static string GetTableName<T>(DbSet<T> dbSet) where T : class
    {
        
        var context = dbSet.GetService<ICurrentDbContext>().Context;
        var entityType = context.Model.FindEntityType(typeof(T));
        var tableName = entityType?.GetTableName()?? throw new Exception("can not get table name");
        return tableName;
    }
    public static List<IProperty> GetPrimaryKey<T>(DbSet<T> dbSet)where T : class
    {
        var entityType = dbSet.EntityType?? throw new Exception("cannot get entity type");
        var primaryKeyProperties = entityType.FindPrimaryKey()?.Properties.Where(p=>p.ValueGenerated==ValueGenerated.OnAdd).ToList();
        if (primaryKeyProperties != null && !primaryKeyProperties.Any())  return new List<IProperty>();
        return primaryKeyProperties!;
    }

    public static List<IProperty> GetAllProperty<T>(DbSet<T> dbSet) where T : class
    {
        
        var entityType = dbSet.EntityType?? throw new Exception("cannot get entity type");
        var allProperties = entityType.GetProperties().ToList();
        return allProperties;
    }
    
    public static ICollection<ICollection<object>> ConvertToListOfLists<T>(List<T> entities)
    {
        var listOfLists = new List<ICollection<object>>();
        var properties = typeof(T).GetProperties();

        foreach (var entity in entities)
        {
            var propertyValues = new List<object>();

            foreach (var property in properties)
            {
                var value = property.GetValue(entity);
                propertyValues.Add(value);
            }

            listOfLists.Add(propertyValues);
        }

        return listOfLists;
    }
    public static List<IProperty> GetNonGeneratedPrimaryKeyProperties<T>(DbSet<T> dbSet) where T: class
    {
        var entityType = dbSet.EntityType?? throw new Exception("cannot get entity type");
        var primaryKey = GetPrimaryKey(dbSet);
        var allProperties = entityType.GetProperties().ToList();
        var nonGeneratedPrimaryKeyProperties = allProperties.Except(primaryKey).ToList();
        return nonGeneratedPrimaryKeyProperties;

    }
    // public static List<string> GetPrimaryKeys<T>(DbSet<T> dbSet) where T: class
    // {   
    //     var context = dbSet.GetService<ICurrentDbContext>().Context;
    //     var entityType = context.Model.FindEntityType(typeof(T))?? throw new Exception("entity type is not exists in dbContext");
    //     var primaryKey = entityType.FindPrimaryKey()?? throw new Exception($"entity {typeof(T).ToString()} does not have any primary key");
    //     if (!primaryKey.Properties.Any()) throw new Exception("entities does not have primary key");
    //     return primaryKey.Properties.Select(x=>x.GetColumnName()).ToList();
    // }


}