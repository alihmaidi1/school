using Bogus;
using Domain.Entities.Teacher.Teacher;
using FluentValidation;
using Microsoft.AspNetCore.Hosting;
using Repository.Teacher.Teacher;
using Shared.Rule;

namespace Admin.Teacher.Teacher.Command.Update;

public class UpdateTeacherValidation:AbstractValidator<UpdateTeacherCommand>
{
    
    public UpdateTeacherValidation(ITeacherRepository teacherRepository,IWebHostEnvironment webHostEnvironment)
    {
        
        RuleFor(x=>x.Id)
            .NotNull()
            .WithMessage("id should be not null")
            .NotEmpty()
            .WithMessage("id should be not empty")
            .Must(id=>teacherRepository.IsExists(new TeacherID(id)))
            .WithMessage("id is not exists in our data");
        
        RuleFor(x => x.Name)
            .NotNull()
            .WithMessage("name should be not null")
            .NotEmpty()
            .WithMessage("name should be not empty");

        RuleFor(x => x)
            .NotEmpty()
            .WithMessage("email should be not empty")
            .NotNull()
            .WithMessage("email should be not null")
            .Must(x=>!teacherRepository.IsUnique(new TeacherID(x.Id),x.Email));
        
        
        RuleFor(x => x.Status)
            .NotEmpty()
            .WithMessage("status should be not empty")
            .NotNull()
            .WithMessage("status should be not null");

        RuleFor(x => x.Password)
            .NotEmpty()
            .WithMessage("password should be not empty")
            .NotNull()
            .WithMessage("password should be not null")
            .MinimumLength(8)
            .WithMessage("password should be at leat 8 charecter");



        RuleFor(x => x.Image)
            .Must(image => FileRule.IsFileExists(image, webHostEnvironment.WebRootPath))
            .WithMessage("this image is not exists in our data");

    }

}