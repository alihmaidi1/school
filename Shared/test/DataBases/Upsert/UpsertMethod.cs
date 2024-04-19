using EntityFramework.BulkExtension.EntityFramework;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace EntityFramework.BulkExtension.DataBases.Upsert;

public class UpsertMethod
{
    /// <summary>
    /// add entity if it is not exists in database and if exists update it
    /// </summary>
    /// <param name="dbSet"></param>
    /// <param name="entity"></param>
    /// <param name="updateConditionColumn">passing property name list that you want to match upsert command to database</param>
    /// <typeparam name="T">you should passing this type as entity framework model</typeparam>
    /// <returns>return if upsert command executed successfully</returns>
    public static bool Upsert<T>(DbSet<T> dbSet,T entity,List<string>? updateConditionColumn=null) where T : class
    {
        ArgumentNullException.ThrowIfNull(dbSet);
        ArgumentNullException.ThrowIfNull(entity);
        var entities = new List<T> { entity };
        UpsertRange(dbSet,entities,updateConditionColumn);
        return true;
    }

    

    public static bool UpsertRange<T>(DbSet<T> dbSet, List<T> entities,List<string>? updateExpression=null) where T : class
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
        using var conn = context.Database.GetDbConnection();
        conn.Open();
        using var transaction = conn.BeginTransaction();
        try
        {

            var tableName = Helper.GetTableName(dbSet);
            var mergeColumns = Helper.GetNonGeneratedPrimaryKeyProperties(dbSet).Select(x=>x.GetColumnName()).ToList();
            var joinColumns =updateCondition??Helper.GetAllProperty(dbSet).Select(x=>x.GetColumnName()).ToList();
            var command=conn.CreateCommand();
            
            command.CommandText = SqlServer.GetCommand(tableName, mergeColumns, joinColumns,Helper.ConvertToListOfLists<T>(entities));
            command.Transaction = transaction;
            command.ExecuteNonQuery();
            transaction.Commit();
        }
        catch (Exception e)
        {
            transaction.Rollback();

            throw;
        }


        
        return true;

    }
    
    
    
}