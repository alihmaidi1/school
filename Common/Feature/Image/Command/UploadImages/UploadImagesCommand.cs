using Common.CQRS;
using Microsoft.AspNetCore.Http;
using Shared.CQRS;

namespace Common.Feature.Image.Command.UploadImages;

public class UploadImagesCommand : ICommand
{
    
    public List<IFormFile> images { get; init; }
    
}