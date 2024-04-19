namespace Shared.File;

public class ImageResponse
{

    public ImageResponse()
    {
        Id = Guid.NewGuid();
    }
    
    public Guid Id { get; set; }
    public string Url { get; set; }

    public string Hash { get; set; }

}