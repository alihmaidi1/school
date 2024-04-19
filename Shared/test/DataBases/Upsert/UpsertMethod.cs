using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace Shared.test.DataBases.Upsert;

public static class UpsertMethod
{
    /// <summary>
    /// add entity if it is not exists in database and if exists update it
    /// </summary>
    /// <param name="dbSet"></param>
    /// <param name="entity"></param>
    /// <param name="updateConditionColumn">passing property name list that you want to match upsert command to database</param>
    /// <typeparam name="T">you should passing this type as entity framework model</typeparam>
    /// <returns>return if upsert command executed successfully</returns>
    public static bool Upsert<T>(this DbSet<T> dbSet,T entity,List<string>? updateConditionColumn=null) where T : class
    {
        ArgumentNullException.ThrowIfNull(dbSet);
        ArgumentNullException.ThrowIfNull(entity);
        var entities = new List<T> { entity };
        UpsertRange(dbSet,entities,updateConditionColumn);
        return true;
    }

    

    public static bool UpsertRange<T>(this DbSet<T> dbSet, List<T> entities,List<string>? updateExpression=null) where T : class
    {
        ArgumentNullException.ThrowIfNull(dbSet);
        ArgumentNullException.ThrowIfNull(entities);
        // ExecuteCommand(dbSet,entities);
        // var dbContext = dbSet.GetService<ICurrentDbContext>().Context;
        return ExecuteCommand(dbSet,entities,updateExpression);
    }
    
    
    
    private static bool ExecuteCommand<T>(DbSet<T> dbSet,List<T> entities,List<string>? updateCondition=null) where T : class
    {


        var context = dbSet.GetService<ICurrentDbContext>().Context;
        
        try
        {

            var tableName = EntityFramework.Helper.GetTableName(dbSet);
            var mergeColumns = EntityFramework.Helper.GetNonGeneratedPrimaryKeyProperties(dbSet).Select(x=>x.GetColumnName()).ToList();
            var joinColumns =updateCondition??EntityFramework.Helper.GetAllProperty(dbSet).Select(x=>x.GetColumnName()).ToList();
            var entityvalues=EntityFramework.Helper.ConvertToListOfLists<T>(entities);
            var command= SqlServer.GetCommand(tableName, mergeColumns, joinColumns,entityvalues);
            context.Database.ExecuteSqlRaw(command);

            
        }
        catch (Exception e)
        {

            throw;
        }


        
        return true;

    }
    
    
    
}