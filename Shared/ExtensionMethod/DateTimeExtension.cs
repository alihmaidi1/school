namespace Common.ExtensionMethod;

public static class DateTimeExtension
{
    public static DateTime RandomDateTime()
    {
        var gen = new Random();
        var start = DateTime.Now;
        return start.AddDays(gen.Next(1, 1000));
    }
}