namespace Common.ExtensionMethod;

public static class CrudOpterationRule
{
    public static Func<string, List<string>, bool> IsValidOrder = (x, validList) =>
    {
        if (x == null) return true;

        var list = x.Split(",").ToList();
        string str_without_minus;
        foreach (var str in list)
        {
            str_without_minus = str;
            if (str.StartsWith("-")) str_without_minus = str.Substring(1);
            if (!validList.Any(x => x.Equals(str_without_minus))) return false;
        }

        return true;
    };
}