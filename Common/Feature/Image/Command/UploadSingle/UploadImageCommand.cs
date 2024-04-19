using System.ComponentModel.DataAnnotations;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Common.Feature.Image.Command.Model;

public class UploadImageCommand:IRequest<JsonResult>
{
 
    
    [DataType(DataType.Upload)]
    public IFormFile Image { get; set; }

}