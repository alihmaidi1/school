using TeacherEntity=Domain.Entities.Teacher.Teacher;
using infrastructure;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Repository.Teacher.Teacher;
using Shared.CQRS;
using Shared.Enum;
using Shared.File;
using Shared.OperationResult;
using Shared.Services.Email;
using Shared.Helper;
using Shared.Constant;

namespace Admin.Teacher.Teacher.Command.Add;

public class AddTeacherHandler:OperationResult,ICommandHandler<AddTeacherCommand>
{
    private readonly IMailService _mailService;

    private readonly ApplicationDbContext _context;

    public AddTeacherHandler(ApplicationDbContext context,IMailService MailService,IConfiguration configuration,IWebHostEnvironment webHostEnvironment,ITeacherRepository TeacherRepository)
    {

        _mailService = MailService;    
        _context=context;
    }
    
    public async Task<JsonResult> Handle(AddTeacherCommand request, CancellationToken cancellationToken)
    {
       
        var image = _context.Images.First(x => x.Id == request.Image);
        var teacher=new TeacherEntity.Teacher(){

            Name=request.Name,
            Email=request.Email,
            Password=PasswordHelper.HashPassword(request.Password),
            Image=image.Url,
            Hash=image.Hash,
            SubjectId=request.SubjectId
        };
        _context.Teachers.Add(teacher);
        _context.Images.Remove(image);
        teacher.SendEmail("new teacher in school",$"you are a new teacher and this is your password{request.Password}");
        await _context.SaveChangesAsync(cancellationToken);
        image.Url.MoveFile(image.Url.GetNewPath(FolderName.Teacher).localPath);
        return Success("teacher was created successfully");
    }
}