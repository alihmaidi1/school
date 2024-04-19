using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.Extensions.Primitives;

namespace EntityFramework.BulkExtension.DataBases.Upsert;

public class SqlServer
{

    public static string GetCommand(string tableName,ICollection<string>columns,ICollection<string> joinColumn,ICollection<ICollection<object>> entities)
    {
        
        var result = new StringBuilder();
        result.Append($"MERGE INTO {tableName} AS TARGET USING (VALUES (");
        result.Append(string.Join("), (",entities.Select(x=>string.Join(", ",x.Select(y=>y)))));
        result.Append($") ) AS SOURCE (");
        result.Append(string.Join(", ",columns));
        result.Append(") ON ");
        result.Append(string.Join(" AND ", joinColumn.Select(x=>$"TARGET.{x}=SOURCE.{x}")));
        result.Append(" WHEN NOT MATCHED  THEN INSERT (");
        result.Append(string.Join(", ", columns.Select(e => e)));
        result.Append(") VALUES (");
        result.Append(string.Join(", ", columns.Select(x=>$"TARGET.{x}")));
        result.Append(')');
        result.Append(" WHEN MATCHED THEN UPDATE SET ");
        result.Append(string.Join(", ",columns.Select(x=>$"TARGET.{x}=SOURCE.{x}")));        
        result.Append(';');
        return result.ToString();
    }

    
}