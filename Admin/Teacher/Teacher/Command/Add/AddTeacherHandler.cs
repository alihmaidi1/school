using Common.CQRS;
using Hangfire;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Repository.Teacher.Teacher;
using Shared.Enum;
using Shared.File;
using Shared.OperationResult;
using Shared.Services.Email;

namespace Admin.Teacher.Teacher.Command.Add;

public class AddTeacherHandler:OperationResult,
    ICommandHandler<AddTeacherCommand>
{
    private ITeacherRepository TeacherRepository;
    private readonly IMailService MailService;


    private IWebHostEnvironment webHostEnvironment;


    private string uri;
    public AddTeacherHandler(IMailService MailService,IConfiguration configuration,IWebHostEnvironment webHostEnvironment,ITeacherRepository TeacherRepository)
    {

        this.MailService = MailService;
        this.TeacherRepository = TeacherRepository;
        uri = configuration["Url"];
        this.webHostEnvironment = webHostEnvironment;
    }
    
    public async Task<JsonResult> Handle(AddTeacherCommand request, CancellationToken cancellationToken)
    {
       
        ImageResponse Image = null;
        if (request.Image is not null)
        {

            Image=request.Image.OptimizeFile(FileName.Teacher.ToString(),
                webHostEnvironment.WebRootPath,
                uri);

        }

        await TeacherRepository.AddAsync(new Domain.Entities.Teacher.Teacher.Teacher()
        {
            
            Name = request.Name,
            Email = request.Email,
            Password = request.Password,
            status = request.Status,
            Image = Image?.Url,
            Hash = Image?.hash,
            Resize = Image?.resized
        });
        BackgroundJob.Enqueue(() =>
            MailService.SendMail(request.Email, "new Teacher Info In School",
                $"this is your email In School and this is your password {request.Password}")
        );


        return Success("admin was added successfully");
    }
}