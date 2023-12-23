using System.Text;

namespace Shared.Extension;

public static class StringExtension
{
    public static string GenerateCode(this string str)
    {

        Random random = new Random();   
        return random.Next(0,1000000).ToString("D6");

    }

    public static string GenerateRandomString(this string str,int length) {
            
        string src = "abcdefghijklmnopqrstuvwxyz0123456789";
        var sb = new StringBuilder();
        Random RNG = new Random();
        for (var i = 0; i < length; i++)
        {
            var c = src[RNG.Next(0, src.Length)];
            sb.Append(c);
        }
        return sb.ToString();



    }

    
}