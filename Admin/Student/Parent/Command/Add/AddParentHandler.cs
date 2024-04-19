using Common.CQRS;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Repository.Student.Parent;
using Shared.CQRS;
using Shared.Enum;
using Shared.File;
using Shared.OperationResult;

namespace Admin.Student.Parent.Command.Add;

public class AddParentHandler:OperationResult,
    ICommandHandler<AddParentCommand>
{

    private IParentRepository ParentRepository;

    private IWebHostEnvironment WebHostEnvironment;

    
    private string uri;
    public AddParentHandler(IConfiguration configuration,IParentRepository ParentRepository,IWebHostEnvironment WebHostEnvironment)
    {

        this.WebHostEnvironment = WebHostEnvironment;

        this.uri = configuration["Url"];
        this.ParentRepository = ParentRepository;
    }
    public async Task<JsonResult> Handle(AddParentCommand request, CancellationToken cancellationToken)
    {

        
        // var Parent = new Domain.Entities.Student.Parent.Parent()
        // {
        //
        //     Name = request.Name,
        //     Email = request.Email,
        //     Password = request.Password,
        //     
        //
        // };
        //
        //
        // if (request.Url is not null)
        // {
        //
        //     var ImageResponse = request.Url.OptimizeFile(FileName.Parent.ToString(),WebHostEnvironment.WebRootPath,uri);
        //
        //     Parent.Image = ImageResponse.Url;
        //     Parent.Resize = ImageResponse.Resized;
        //     Parent.Hash = ImageResponse.Hash;
        //
        // }
        //
        //
        // await ParentRepository.AddAsync(Parent);
        //
        // return Success("paernt was added successfully");

        return null;
    }
}