using Common.CQRS;
using Shared.CQRS;

namespace Common.Feature.Image.Command.UploadBase64;

public class UploadBase64Command : ICommand
{
    
    
    public string Image { get; init; }
    
    
}