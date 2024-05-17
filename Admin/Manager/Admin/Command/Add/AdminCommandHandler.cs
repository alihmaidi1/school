using Domain.Event;
using infrastructure;
using Microsoft.AspNetCore.Mvc;
using Shared.Constant;
using Shared.CQRS;
using Shared.File;
using Shared.Helper;
using Shared.OperationResult;
using Shared.Services.Email;

namespace Admin.Manager.Admin.Command.Add;

public class AdminCommandHandler:OperationResult,ICommandHandler<AddAdminCommand>
{
 
 
    private readonly ApplicationDbContext _context;
    
    private readonly IMailService _mailService;
    public AdminCommandHandler(ApplicationDbContext context, IMailService mailService)
    {

        _context = context;
        _mailService = mailService;

    }
    
    public async Task<JsonResult> Handle(AddAdminCommand request, CancellationToken cancellationToken)
    {

        var image = _context.Images.FirstOrDefault(x => x.Id == request.ImageId);
        if (image is null)
        {
            return ValidationError("ImageId", "this image is not exists in our data");
        }
        
        var admin = new Domain.Entities.Manager.Admin.Admin();
        admin.Name = request.Name;
        admin.Email = request.Email;
        admin.RoleId = request.RoleId;
        admin.Password = PasswordHelper.HashPassword(request.Password);
        admin.Image = image.Url.GetNewPath(FolderName.Admin).httpPath;
        admin.Hash = image.Hash;
        _context.Images.Remove(image);
        _context.Admins.Add(admin);
        admin.SendEmail("You are a New Admin",$"this this your password {request.Password}");
        await _context.SaveChangesAsync(cancellationToken);
        image.Url.MoveFile(image.Url.GetNewPath(FolderName.Admin).localPath);
        return Success("admin was created successfully");
        
    
    }
}