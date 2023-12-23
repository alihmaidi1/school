using Microsoft.AspNetCore.Http;
using Shared.File;

namespace Shared.Rule;

public static class FileRule
{
    
    public static Func<IFormFile,bool> IsFile = x =>
    {

        if (x?.ContentType is null)
            return false;
        if (x.ContentType.Equals("image/jpeg") ||
            x.ContentType.Equals("image/jpg") ||
            x.ContentType.Equals("image/png")
           )
            return true;
        return false;
    };


    public static Func<string,string, bool> isFileExists = (x,wwwroot) =>
    {

        if (x is null)
        {

            return true;

        }

        return FileExtension.IsImageExists(x, wwwroot);
            
    };
}