
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
namespace Shared.Entity.EntityOperation.BulkMerge;

public static class BulkMergeHelper
{


    public static void BulkMerge<T>(DbSet<T> dbSet,List<T> entities) where T : class
    {


        var context = dbSet.GetService<ICurrentDbContext>().Context;
        using var conn = (SqlConnection)context.Database.GetDbConnection();
        conn.Open();
        using var transaction = conn.BeginTransaction();
        try
        {

            var tableName = EntityFrameworkHelper.GetTableName(dbSet);
            var primaryKeyHasDefaultValue = EntityFrameworkHelper.HasPrimaryKey(dbSet);
            var identityInsertEnabled = SqlServerHelperMethod.DisableIdentityInsertIfNeeded(conn, transaction, tableName, primaryKeyHasDefaultValue);
    
    
            if (identityInsertEnabled)
            {
                SqlServerHelperMethod.EnableIdentityInsert(conn, transaction, tableName);
            }
    
            transaction.Commit();
        }
        catch (Exception e)
        {
            transaction.Rollback();

            throw;
        }
        


    }

}