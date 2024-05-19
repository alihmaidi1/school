using Common.CQRS;
using infrastructure;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Shared.Constant;
using Shared.CQRS;
using Shared.Enum;
using Shared.File;
using Shared.Helper;
using Shared.OperationResult;

namespace Admin.Student.Parent.Command.Add;

public class AddParentHandler:OperationResult,ICommandHandler<AddParentCommand>
{


    private ApplicationDbContext _context;
    public AddParentHandler(ApplicationDbContext context)
    {

        _context=context;

    }
    public async Task<JsonResult> Handle(AddParentCommand request, CancellationToken cancellationToken)
    {

        var image = _context.Images.FirstOrDefault(x => x.Id == request.Image);
        
        var Parent = new Domain.Entities.Student.Parent.Parent()
        {
        
            Name = request.Name,
            Email = request.Email,
            Password = PasswordHelper.HashPassword(request.Password),
            Image = image.Url.GetNewPath(FolderName.Parent).httpPath,
            Hash=image.Hash
            
        
        };

        Parent.SendEmail("You are a New Parent",$"this this your password {request.Password}");
        _context.Images.Remove(image);
        _context.Parents.Add(Parent);
        await _context.SaveChangesAsync(cancellationToken);
        image.Url.MoveFile(image.Url.GetNewPath(FolderName.Parent).localPath);
        return Success("Parent was created successfully");


    }
}