using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Common.Feature.Image.Command.Model;

public class UploadImagesCommand:IRequest<JsonResult>
{
    
    
    public List<IFormFile> images { get; set; }

}