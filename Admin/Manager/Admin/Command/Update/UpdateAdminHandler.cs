using Common.CQRS;
using Domain.Entities.Manager.Admin;
using Domain.Entities.Role;
using Hangfire;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Repository.Manager.Admin;
using Shared.Enum;
using Shared.File;
using Shared.OperationResult;
using Shared.Services.Email;

namespace Admin.Manager.Admin.Command.Update;

public class UpdateAdminHandler:OperationResult,
    ICommandHandler<UpdateAdminCommand>

{
    private readonly IAdminRepository AdminRepository;

    private readonly IMailService MailService;

    private IWebHostEnvironment webHostEnvironment;

    private string uri;
    public UpdateAdminHandler(IConfiguration configuration,IWebHostEnvironment webHostEnvironment, IAdminRepository AdminRepository, IMailService MailService)
    {

        uri = configuration["Url"];
        this.webHostEnvironment = webHostEnvironment;
        this.MailService = MailService;
        
        this.AdminRepository = AdminRepository;

    }
    
    
    public async Task<JsonResult> Handle(UpdateAdminCommand request, CancellationToken cancellationToken)
    {

        var oldAdmin = AdminRepository.GetInfo(new AdminID(request.AdminId));
        var Admin = new Domain.Entities.Admin.Admin()
        {

            Id = new AdminID(request.AdminId),
            RoleId = new RoleID(request.RoleId),
            Email = request.Email,
            Password = request.Password,
            Status = request.Status,
            Name = request.Name,
            Image = oldAdmin.Image,
            Resize = oldAdmin.Resize,
            Hash = oldAdmin.Hash
        };

        if (request.Image is not null)
        {

            var imageResponse = request.Image.OptimizeFile(FileName.Admin.ToString(),webHostEnvironment.WebRootPath,uri);
            Admin.Image = imageResponse.Url;
            Admin.Resize = imageResponse.resized;
            Admin.Hash = imageResponse.hash;
            if (oldAdmin.Image is not null)
            {
                File.Delete(oldAdmin.Image);
                File.Delete(oldAdmin.Resize);
            }
        }
        await AdminRepository.UpdateAsync(Admin);
        BackgroundJob.Enqueue(() =>
                
            MailService.SendMail(request.Email, "new Admin In School",
                $"You Are New Manager In School and this is your password {request.Password}")
        );

        return Success("admin was updated successfully");
    }
}