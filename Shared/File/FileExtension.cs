using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Shared.Constant;
using Shared.Exceptions;
using Shared.Extension;

namespace Shared.File;

public static class FileExtension
{
    public static string UploadImage(this IFormFile image)
    {
        try
        {
            var accessor = new HttpContextAccessor();
            var wwwroot=accessor.HttpContext?.RequestServices.GetService<IWebHostEnvironment>()?.WebRootPath??"";

            var imageinfo = image.GetImagePath(wwwroot);
            using FileStream fileStream = new FileStream(imageinfo.imagepath, FileMode.Create);
            image.CopyTo(fileStream);
            return accessor.GetBaseUri()+"/"+imageinfo.imagename;

        }
        catch (Exception ex)
        {
            throw new IOStreamException(ex.Message);
        }


    }

    public static string UploadFile(this IFormFile image,string FolderName=FolderName.Temp)
    {
        try
        {
            var accessor = new HttpContextAccessor();
            var wwwroot=accessor.HttpContext?.RequestServices.GetService<IWebHostEnvironment>()?.WebRootPath??"";

            var imageinfo = image.GetImagePath(wwwroot,FolderName);
            using FileStream fileStream = new FileStream(imageinfo.imagepath, FileMode.Create);
            image.CopyTo(fileStream);
            return accessor.GetBaseUri()+"/"+imageinfo.imagename;

        }
        catch (Exception ex)
        {
            throw new IOStreamException(ex.Message);
        }


    }
    
    
    private static (string imagepath,string imagename) GetImagePath(this IFormFile image,string wwwroot,string FolderName=FolderName.Temp)
    {


        string tempDirectory = Path.Combine(wwwroot, FolderName);
        if (!Directory.Exists(tempDirectory))
        {
            Directory.CreateDirectory(tempDirectory);
        }

        string imageName = Guid.NewGuid().ToString()+Path.GetExtension(image.FileName);
        imageName=FolderName+"/"+imageName;
        string imagePath = wwwroot+"/"+ imageName;
        return (imagePath,imageName); 

    }

    
    public static string UploadBase64Image(this string image)
    {

        try
        {
            var accessor = new HttpContextAccessor();
            var wwwroot=accessor.HttpContext?.RequestServices.GetService<IWebHostEnvironment>()?.WebRootPath??"";

            var stream=image.CreateBase64Stream(wwwroot);
            using FileStream fileStream = new FileStream(stream.imagePath, FileMode.Create);
            fileStream.Write(stream.bytes,0, stream.bytes.Length);
            return accessor.GetBaseUri()+"/"+stream.imageName; 

        }
        catch(Exception ex)
        {
            throw new IOStreamException(ex.Message);
        }


    }
    
    private static (string imagePath,string imageName, byte[] bytes) CreateBase64Stream(this string image,string WebRootPath)
    {
        (string base64, string extension) file = image.GetBase64Info();
        var bytes = Convert.FromBase64String(file.base64);
        string tempDirectory = Path.Combine(WebRootPath, FolderName.Temp);
        if (!Directory.Exists(tempDirectory))
        {
            Directory.CreateDirectory(tempDirectory);
        }
        var imageName = Guid.NewGuid().ToString() + "." + file.extension;
        string imagePath = Path.Combine(tempDirectory, imageName);
        imageName = FolderName.Temp+"/"+ imageName;
        return (imagePath,imageName,bytes);
    }

    private static (string base64, string extension) GetBase64Info(this string base64File)
    {

        var base64 = base64File.Substring(base64File.IndexOf(",") + 1);
        var extensionLength= base64File.IndexOf(";") - base64File.IndexOf("/");
        var extension = base64File.Substring(base64File.IndexOf("/") + 1, extensionLength - 1);
        return (base64, extension);
    }


    public static List<string> UploadImages(this List<IFormFile>images, string webRootPath,string host) 
    {

        List<string> uploadedImages=Enumerable.Empty<string>().ToList();
        var tasks = images.Select(x=>Task.FromResult(UploadImage(x))).ToList();
        Task.WhenAll(tasks);
        var result = tasks.Select(t => t.GetAwaiter().GetResult()).ToList();
        return uploadedImages;

    }

    public static bool IsImageExists(string imagePath,string wwwroot)
    {
        string image = Path.GetFileName(imagePath);
        string newImage = Path.Combine(wwwroot, FolderName.Temp, image);
        return  System.IO.File.Exists(newImage);
                        

    }


    public static bool IsBase64Image(this string base64File)
    {

        var base64 = base64File.Substring(base64File.IndexOf(",") + 1);
        Span<byte> buffer = new Span<byte>(new byte[base64.Length]);
        return Convert.TryFromBase64String(base64,buffer,out int bytesParsed);

    }


    // private static string GetImageHash(this FileStream imagePath)
    // {
    //     try
    //     {
    //             
    //         using var imageStream = SixLabors.ImageSharp.Image.Load<Rgb24>(imagePath);
    //         return Blurhasher.Encode(imageStream, 4, 3);
    //     }
    //     catch(Exception ex) 
    //     {
    //         throw new IOException(ex.Message);
    //     }
    // }


    // public static string resizeImage(this FileStream imagepath,string filePath,string wwwroot,string Folder,int Width=300,int Height = 300)
    // {
    //     Image img = Bitmap.FromStream(imagepath);
    //     var imageResized = ImageResize.Scale(img, Width, Height);
    //     
    //     var resizepath =Path.Combine(Folder,Guid.NewGuid().ToString()+".png");
    //     imageResized.Save(Path.Combine(wwwroot,resizepath));
    //     return Path.Combine(filePath,resizepath);
    //
    // }

    public static ImageResponse OptimizeFile(this IFormFile file)
    {
        
        
        var image = UploadImage(file);
        var hash = "LEHV6nWB2yk8pyo0adR*.7kCMdnj";
        return new ImageResponse
        {
            Url=image,
            Hash=hash
                
        };
    }

    public static async Task<List<ImageResponse>> OptimizeMany(this List<IFormFile> images)
    {

        var uploadImagesTask = images.Select(x =>Task.FromResult(OptimizeFile(x))).ToList();
        await Task.WhenAll(uploadImagesTask);
        return uploadImagesTask.Select(x => x.GetAwaiter().GetResult()).ToList();

    }
    

    
    
    public static ImageResponse OptimizeBase64(this string file)
    {
        
        
        var image = UploadBase64Image(file);
        var hash = "LEHV6nWB2yk8pyo0adR*.7kCMdnj";
        
        return new ImageResponse
        {
            Url=image,
            Hash=hash
                
        };
    }


    public static bool MoveFile(this string file,string newPath)
    {
        var accessor = new HttpContextAccessor();
        var wwwroot=accessor.HttpContext?.RequestServices.GetService<IWebHostEnvironment>()?.WebRootPath??"";
        var image = Path.Combine(wwwroot,FolderName.Temp,Path.GetFileName(file));
        var newPath1= newPath.Split(Path.GetFileName(newPath))[0];
        if(!Directory.Exists(newPath1)) Directory.CreateDirectory(newPath1);
        System.IO.File.Move(image,newPath);
        return true;

    }

    public static (string httpPath,string localPath) GetNewPath(this string file,string folderName)
    {
        var accessor = new HttpContextAccessor();
        var wwwroot=accessor.HttpContext?.RequestServices.GetService<IWebHostEnvironment>()?.WebRootPath??"";
        var localPath = Path.Combine(wwwroot,folderName,Path.GetFileName(file));
        var httpPath = accessor.GetBaseUri() + "/" + folderName + "/" + Path.GetFileName(file);
        return (httpPath,localPath);
    }

}