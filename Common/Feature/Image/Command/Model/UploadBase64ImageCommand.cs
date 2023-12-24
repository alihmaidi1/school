using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Common.Feature.Image.Command.Model;

public class UploadBase64ImageCommand:IRequest<JsonResult>
{
    
    
    public string Image { get; set; }

}