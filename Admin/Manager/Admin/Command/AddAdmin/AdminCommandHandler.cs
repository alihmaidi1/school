using Common.CQRS;
using Domain.Entities.Role;
using Hangfire;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Repository.Manager.Admin;
using Shared.Enum;
using Shared.File;
using Shared.OperationResult;
using Shared.Services.Email;

namespace Admin.Admin.Command.AddAdmin;

public class AdminCommandHandler:OperationResult,
    ICommandHandler<AddAdminCommand>
{
 
    private readonly IAdminRepository AdminRepository;

    private readonly IMailService MailService;
    private IWebHostEnvironment webHostEnvironment;
    private string uri;
    public AdminCommandHandler(IAdminRepository AdminRepository, IMailService MailService,IWebHostEnvironment webHostEnvironment,IConfiguration configuration)
    {

        uri = configuration["Url"];
        this.webHostEnvironment = webHostEnvironment;
        this.MailService = MailService;
        this.AdminRepository = AdminRepository;

    }
    
    public async Task<JsonResult> Handle(AddAdminCommand request, CancellationToken cancellationToken)
    {
        var id = Guid.NewGuid();

        ImageResponse Image = null;
        if (request.Image is not null)
        {

            Image=request.Image.OptimizeFile(FileName.Admin.ToString(),
    webHostEnvironment.WebRootPath,
      uri);

        }
        
        
        
        await AdminRepository.AddAsync(new Domain.Entities.Admin.Admin()
        {
            Email = request.Email,
            Password = request.Password,
            Name = request.Name,
            RoleId = new RoleID(request.RoleId),
            Image = Image?.Url,
            Hash = Image?.hash,
            Resize = Image?.resized
        });
        BackgroundJob.Enqueue(() =>
            MailService.SendMail(request.Email, "new Admin In School",
                $"You Are New Manager In School and this is your password {request.Password}")
        );

        return Success("admin was added successfully");
    }
}