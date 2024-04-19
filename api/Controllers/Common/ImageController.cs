using Common.Feature.Image.Command.UploadBase64;
using Common.Feature.Image.Command.UploadImages;
using Common.Feature.Image.Command.UploadSingle;
using Domain.AppMetaData.Common;
using Microsoft.AspNetCore.Mvc;
using schoolManagement.Base;
using Shared.File;
using Shared.OperationResult;
using Shared.OperationResult.Base;
using Shared.Swagger;

namespace schoolmanagment.Controllers.Common;


[ApiGroup(ApiGroupName.All, ApiGroupName.Admin, ApiGroupName.Parent,ApiGroupName.Student,ApiGroupName.Teacher)]

[Route("Api/Common/[controller]/[action]")]

public class ImageController:ApiController
{
    


    
    /// <summary>
    /// upload image with at great size is 1 mega
    /// </summary>
    [Produces(typeof(OperationResultBase<ImageResponse>))]
    [HttpPost]
    public async Task<IActionResult> UploadImage(UploadImageCommand commands)
    {

        var response=await this.Mediator.Send(commands);
        return response;


    }

    
    
    /// <summary>
    /// upload base64 image 
    /// </summary>
    [HttpPost]
    
    [Produces(typeof(OperationResultBase<ImageResponse>))]

    public async Task<IActionResult> UploadBase64Image([FromBody] UploadBase64Command commands)
    {

        var response=await this.Mediator.Send(commands);
        return response;
        
    }
    
    
    /// <summary>
    /// upload images with at great size is 1 mega for one
    /// </summary>
    [HttpPost]
    [Produces(typeof(OperationResultBase<List<ImageResponse>>))]
    public async Task<IActionResult> UploadImages(UploadImagesCommand commands)
    {

        var response=await Mediator.Send(commands);

        return response;

    }
    
}