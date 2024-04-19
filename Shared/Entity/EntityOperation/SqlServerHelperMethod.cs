using Microsoft.Data.SqlClient;

namespace Shared.Entity.EntityOperation;

public static class SqlServerHelperMethod
{
    public static bool DisableIdentityInsertIfNeeded(SqlConnection conn, SqlTransaction transaction, string tableName, bool hasIdentityPrimaryKey)
    {
        if (hasIdentityPrimaryKey)
        {
            var disableIdentityInsertCommand = $"SET IDENTITY_INSERT {tableName} ON";
            using (var command = new SqlCommand(disableIdentityInsertCommand, conn, transaction))
            {
                command.ExecuteNonQuery();
            }

            return true;
        }

        return false;
    }


    public static void EnableIdentityInsert(SqlConnection conn, SqlTransaction transaction, string tableName)
    {
        var enableIdentityInsertCommand = $"SET IDENTITY_INSERT {tableName} OFF";
        using (var command = new SqlCommand(enableIdentityInsertCommand, conn, transaction))
        {
            command.ExecuteNonQuery();
        }
    }
    
    
    private static string ValueToSqlString(object value)
    {
        if (value is null)
        {
            return "NULL";
        }
        else if (value is string || value is char)
        {
            return $"'{value.ToString()!.Replace("'", "''")}'";
        }
        else
        {
            return value.ToString();
        }
    }
    
}