using Hangfire;
using infrastructure;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Repository.Teacher.Teacher;
using Shared.Constant;
using Shared.CQRS;
using Shared.File;
using Shared.Helper;
using Shared.OperationResult;
using Shared.Services.Email;

namespace Admin.Teacher.Teacher.Command.Update;

public class UpdateTeacherHandler:OperationResult,ICommandHandler<UpdateTeacherCommand>
{
    private ITeacherRepository _teacherRepository;
    private ApplicationDbContext _context;

    private readonly IMailService _mailService;

    public UpdateTeacherHandler(ApplicationDbContext context,IMailService MailService,IConfiguration configuration,ITeacherRepository TeacherRepository,IWebHostEnvironment webHostEnvironment)
    {

        _context=context;

        _mailService = MailService;
        _teacherRepository = TeacherRepository;

    }
    
    public async Task<JsonResult> Handle(UpdateTeacherCommand request, CancellationToken cancellationToken)
    {
        
        var image=_context.Images.First(x=>x.Id==request.Image);
        
        var teacher = new Domain.Entities.Teacher.Teacher.Teacher()
        {
        
            Id = request.Id,
            Email = request.Email,
            Password = PasswordHelper.HashPassword(request.Password),
            Name = request.Name
        };

        
        if (request.Image is not null){

            teacher.Image=image.Url.GetNewPath(FolderName.Teacher).httpPath;
            teacher.Hash=image.Hash;
            _context.Images.Remove(image);
        }
        _context.Teachers.Update(teacher);
        teacher.SendEmail("Update Teacher Info In School",$"this is your email In School and this is your password {request.Password}");
        await _context.SaveChangesAsync(cancellationToken);
        if(request.Image is not null) image!.Url.MoveFile(image.Url.GetNewPath(FolderName.Teacher).localPath);
        return Success("admin was updated successfully");
    }
}