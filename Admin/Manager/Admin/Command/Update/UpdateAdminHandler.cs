using Common.CQRS;
using Domain.Entities.Manager.Admin;
using Domain.Entities.Role;
using Hangfire;
using infrastructure;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Repository.Manager.Admin;
using Shared.Constant;
using Shared.CQRS;
using Shared.Enum;
using Shared.File;
using Shared.Helper;
using Shared.OperationResult;
using Shared.Services.Email;

namespace Admin.Manager.Admin.Command.Update;

public class UpdateAdminHandler:OperationResult,ICommandHandler<UpdateAdminCommand>

{
    private readonly IAdminRepository AdminRepository;

    private readonly IMailService MailService;

    private IWebHostEnvironment webHostEnvironment;
    private ApplicationDbContext _context;

    private string uri;
    public UpdateAdminHandler(ApplicationDbContext context,IConfiguration configuration,IWebHostEnvironment webHostEnvironment, IAdminRepository AdminRepository, IMailService MailService)
    {

        uri = configuration["Url"];
        this.webHostEnvironment = webHostEnvironment;
        this.MailService = MailService;
        _context=context;
        this.AdminRepository = AdminRepository;

    }
    
    
    public async Task<JsonResult> Handle(UpdateAdminCommand request, CancellationToken cancellationToken)
    {

        var Admin = _context.Admins.IgnoreQueryFilters().First(x=>x.Id==request.AdminId);
        var image = _context.Images.FirstOrDefault(x => x.Id == request.Image);
        
        Admin.RoleId=request.RoleId;
        Admin.Email=request.Email;
        Admin.Password=PasswordHelper.HashPassword(request.Password);
        Admin.Status=request.Status;
        Admin.Name=request.Name;
        if(request.Image is not null){

            Admin.Image=image!.Url.GetNewPath(FolderName.Admin).httpPath;
            Admin.Hash=image.Hash;
            _context.Images.Remove(image);
        }
        _context.Admins.Update(Admin);
        Admin.SendEmail("update admin info",$"this is your new password{request.Password}");
        await _context.SaveChangesAsync(cancellationToken);
        if(request.Image is not null) image!.Url.MoveFile(image.Url.GetNewPath(FolderName.Admin).localPath);
        return Success("admin was updated successfully");

    }
}