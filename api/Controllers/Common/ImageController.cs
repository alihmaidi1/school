using Common.Feature.Image.Command.Model;
using Domain.AppMetaData.Common;
using Microsoft.AspNetCore.Mvc;
using schoolmanagment.Base;
using Shared.Swagger;

namespace schoolmanagment.Controllers.Common;


public class ImageController:ApiController
{
    
    [ApiGroup(ApiGroupName.All, ApiGroupName.Admin, ApiGroupName.Parent,ApiGroupName.Student,ApiGroupName.Teacher)]


    [HttpPost(ImageRouter.UploadSingle)]
    public async Task<IActionResult> UploadImage(UploadImageCommand commands)
    {

        var response=await this.Mediator.Send(commands);
        return response;


    }

    
    [HttpPost(ImageRouter.UploadBase64Image)]
    [ApiGroup(ApiGroupName.All, ApiGroupName.Admin, ApiGroupName.Parent,ApiGroupName.Student,ApiGroupName.Teacher)]
    
    public async Task<IActionResult> UploadBase64Image([FromBody] UploadBase64ImageCommand commands)
    {

        var response=await this.Mediator.Send(commands);
        return response;
        
    }
    
    
    [HttpPost(ImageRouter.UploadImages)]
    
    [ApiGroup(ApiGroupName.All, ApiGroupName.Admin, ApiGroupName.Parent,ApiGroupName.Student,ApiGroupName.Teacher)]

    public async Task<IActionResult> UploadImages(UploadImagesCommand commands)
    {


        var response=await Mediator.Send(commands);

        return response;

    }
    
}