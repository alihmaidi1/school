namespace Domain.AppMetaData.Common;

public class ImageRouter
{
    
    private const string prefix = Router.Rule + "image";
    public const string UploadSingle = prefix + "/uploadsingle";
    public const string UploadBase64Image = prefix + "/uploadbase64image";
    public const string UploadImages = prefix + "/uploadimages";

}