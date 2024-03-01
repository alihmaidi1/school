using Common.CQRS;
using Domain.Entities.Teacher.Teacher;
using Hangfire;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Repository.Manager.Admin;
using Repository.Teacher.Teacher;
using Shared.Enum;
using Shared.File;
using Shared.OperationResult;
using Shared.Services.Email;

namespace Admin.Teacher.Teacher.Command.Update;

public class UpdateTeacherHandler:OperationResult,
    ICommandHandler<UpdateTeacherCommand>
{
    private ITeacherRepository TeacherRepository;
    private IWebHostEnvironment webHostEnvironment;
    private string uri;
    private readonly IMailService MailService;

    public UpdateTeacherHandler(IMailService MailService,IConfiguration configuration,ITeacherRepository TeacherRepository,IWebHostEnvironment webHostEnvironment)
    {

        this.MailService = MailService;
        uri = configuration["Url"];
        this.webHostEnvironment = webHostEnvironment;
        this.TeacherRepository = TeacherRepository;

    }
    
    public async Task<JsonResult> Handle(UpdateTeacherCommand request, CancellationToken cancellationToken)
    {
        
        var oldAdmin = TeacherRepository.Get(new TeacherID(request.Id));
        var Admin = new Domain.Entities.Teacher.Teacher.Teacher()
        {

            Id = new TeacherID(request.Id),
            Email = request.Email,
            Password = request.Password,
            Name = request.Name,
            Image = oldAdmin.Image,
            Resize = oldAdmin.Resize,
            Hash = oldAdmin.Hash
        };

        if (request.Image is not null)
        {

            var imageResponse = request.Image.OptimizeFile(FileName.Teacher.ToString(),webHostEnvironment.WebRootPath,uri);
            Admin.Image = imageResponse.Url;
            Admin.Resize = imageResponse.resized;
            Admin.Hash = imageResponse.hash;
            if (oldAdmin.Image is not null)
            {
                File.Delete(oldAdmin.Image);
                File.Delete(oldAdmin.Resize);
            }
        }

        TeacherRepository.UpdateAsync(Admin);
        BackgroundJob.Enqueue(() =>
            MailService.SendMail(request.Email, "Update Teacher Info In School",
                $"this is your email In School and this is your password {request.Password}")
        );

        
        return Success("admin was updated successfully");
    }
}