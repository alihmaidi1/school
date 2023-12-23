using System.Drawing;
using System.Drawing.Imaging;
using Blurhash.ImageSharp;
using LazZiya.ImageResize;
using Microsoft.AspNetCore.Http;
using Shared.Constant;
using Shared.Exceptions;
using SixLabors.ImageSharp.PixelFormats;

namespace Shared.File;

public static class FileExtension
{
    public static string UploadImage(this IFormFile image,string WebRootPath,string host)
    {
        try
        {
            var imageinfo = image.GetImagePath(WebRootPath);
            using FileStream fileStream = new FileStream(imageinfo.imagepath, FileMode.Create);
            image.CopyTo(fileStream);
            return Path.Combine(host, imageinfo.imagename);

        }
        catch (Exception ex)
        {
            throw new IOStreamException(ex.Message);
        }


    }
    
    public static (string imagepath,string imagename) GetImagePath(this IFormFile image,string wwwroot)
    {

        string TempDirectory = Path.Combine(wwwroot, FolderName.Temp);
        if (!Directory.Exists(TempDirectory))
        {
            Directory.CreateDirectory(TempDirectory);
        }
        string imageName = Guid.NewGuid().ToString() + image.FileName;
        imageName=Path.Combine(FolderName.Temp,imageName);
        string imagePath = Path.Combine(wwwroot, imageName);
        return (imagePath,imageName); 

    }

    
    public static string UploadBase64Image(this string image, string wwwroot,string host)
    {

        try
        {
            var Stream=image.createBase64Stream(wwwroot);
            using FileStream fileStream = new FileStream(Stream.imagePath, FileMode.Create);
            fileStream.Write(Stream.bytes,0, Stream.bytes.Length);
            return Path.Combine(host,Stream.imageName); 


        }
        catch(Exception ex)
        {
            throw new IOStreamException(ex.Message);
        }


    }
    
    private static (string imagePath,string imageName, byte[] bytes) createBase64Stream(this string image,string WebRootPath)
    {
        (string base64, string extension) file = image.GetBase64Info();
        var bytes = Convert.FromBase64String(file.base64);
        string TempDirectory = Path.Combine(WebRootPath, FolderName.Temp);
        if (!Directory.Exists(TempDirectory))
        {
            Directory.CreateDirectory(TempDirectory);
        }
        var imageName = Guid.NewGuid().ToString() + "." + file.extension;
        string imagePath = Path.Combine(TempDirectory, imageName);
        imageName = Path.Combine(FolderName.Temp, imageName);

        return (imagePath,imageName,bytes);
    }

    public static (string base64, string extension) GetBase64Info(this string base64File)
    {

        var base64 = base64File.Substring(base64File.IndexOf(",") + 1);
        var ExtensionLength= base64File.IndexOf(";") - base64File.IndexOf("/");
        var extension = base64File.Substring(base64File.IndexOf("/") + 1, ExtensionLength - 1);
        return (base64, extension);
    }


    public static List<string> UploadImages(this List<IFormFile>images, string webRootPath,string host) 
    {

        List<string> UploadedImages=Enumerable.Empty<string>().ToList();

        images.ForEach(image =>
        {

            string imagePath = UploadImage(image, webRootPath,host);
            UploadedImages.Add(imagePath);

        });
            
        return UploadedImages;

    }

    public static bool IsImageExists(string imagepath,string wwwroot)
    {
        string image = Path.GetFileName(imagepath);
        string newimage = Path.Combine(wwwroot, FolderName.Temp, image);
        return  System.IO.File.Exists(newimage);
                        

    }


    public static bool IsBase64Image(this string base64File)
    {

        var base64 = base64File.Substring(base64File.IndexOf(",") + 1);
        Span<byte> buffer = new Span<byte>(new byte[base64.Length]);
        return Convert.TryFromBase64String(base64,buffer,out int bytesParsed);

    }


    public static string GetImageHash(this FileStream imagepath)
    {
        try
        {
                
            using var imageStream = SixLabors.ImageSharp.Image.Load<Rgb24>(imagepath);
            return Blurhasher.Encode(imageStream, 4, 3);
        }
        catch(Exception ex) 
        {
            throw new IOException(ex.Message);
        }
    }


    public static (string imagefile,MemoryStream memorystream)resizeImage(this FileStream imagepath,string Folder,int Width=300,int Height = 300)
    {
            
        Image img = Bitmap.FromStream(imagepath);
            
        var imageResized = ImageResize.Scale(img, Width, Height);
        var resizepath = Guid.NewGuid().ToString() + ".png";
        resizepath=Folder+"/"+ resizepath;
        MemoryStream memoryStream = new MemoryStream();
        imageResized.Save(memoryStream, ImageFormat.Png);
        return (resizepath, memoryStream);

         

    }


}