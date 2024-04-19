namespace Shared.test.DataBases;

public class ExtensionMethods
{


    public static List<string> SupportedDatabaseForUpsertMethod()
    {

        var list = new List<string>();
        list.Add("Microsoft.EntityFrameworkCore.SqlServer");

        return list;
    }

    
    
    
}