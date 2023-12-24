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
                          IRequestHandler<UploadImageCommand, JsonResult>

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
}
