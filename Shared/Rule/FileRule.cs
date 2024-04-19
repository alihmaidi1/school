using Microsoft.AspNetCore.Http;
using Shared.File;

namespace Shared.Rule;

public static class FileRule
{
    
    public static Func<IFormFile,bool> IsFile = x =>
    {

        if (x is null)
            return false;

        var Extension = Path.GetExtension(x.FileName);
        if (Extension==".jpeg" ||
            Extension==".jpg" ||
            Extension==".png"
           )
            return true;
        return false;
    };


    
    public static Func<IFormFile,bool> IsPDF = x =>
    {

        if (x is null)
            return false;

        var Extension = Path.GetExtension(x.FileName);
        if (Extension==".pdf"
           )
            return true;
        return false;
    };


    public static Func<string,string, bool> IsFileExists = (x,wwwroot) =>
    {

        if (x is null)
        {

            return true;

        }

        return FileExtension.IsImageExists(x, wwwroot);
            
    };
}