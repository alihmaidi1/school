using Castle.Core.Configuration;
using Common.Feature.Image.Command.Model;
using MediatR;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;
using Shared.Extension;
using Shared.File;
using Shared.OperationResult;

namespace Common.Feature.Image.Command.Handler;

public class ImageHandler:OperationResult,
                          IRequestHandler<UploadImageCommand, JsonResult>,
                          IRequestHandler<UploadBase64ImageCommand, JsonResult>,
                          IRequestHandler<UploadImagesCommand, JsonResult>



{
    
    private readonly IWebHostEnvironment webHost;
    private IHttpContextAccessor httpContextAccessor;
    
    public ImageHandler(IWebHostEnvironment webHost,IHttpContextAccessor httpContextAccessor)
    {

        this.httpContextAccessor = httpContextAccessor;
        this.webHost = webHost;
    }
    
    public async Task<JsonResult>  Handle(UploadImageCommand request, CancellationToken cancellationToken)
    {
        string host = httpContextAccessor.GetBaseUri();
        var image = request.Image.UploadImage(webHost.WebRootPath,host);

        return Success(image,"The Image Was Uploaded Successfully");

    }

    public async Task<JsonResult> Handle(UploadBase64ImageCommand request, CancellationToken cancellationToken)
    {
        string host = httpContextAccessor.GetBaseUri();

        string image = request.Image.UploadBase64Image(webHost.WebRootPath,host);
        return Success(image,"The Image Was Uploaded Successfully");

    }

    public async Task<JsonResult> Handle(UploadImagesCommand request, CancellationToken cancellationToken)
    {
        string host = httpContextAccessor.GetBaseUri();
        var images = request.images.UploadImages(webHost.WebRootPath,host);
        return Success(images, "The Images Was Uploaded Successfully");

    }
}
