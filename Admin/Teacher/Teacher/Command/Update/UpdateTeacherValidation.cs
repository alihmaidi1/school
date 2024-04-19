using Bogus;
using Domain.Entities.Teacher.Teacher;
using FluentValidation;
using infrastructure;
using Microsoft.AspNetCore.Hosting;
using Repository.Teacher.Teacher;
using Shared.Rule;

namespace Admin.Teacher.Teacher.Command.Update;

public class UpdateTeacherValidation:AbstractValidator<UpdateTeacherCommand>
{
    
    public UpdateTeacherValidation(ApplicationDbContext context ,ITeacherRepository teacherRepository,IWebHostEnvironment webHostEnvironment)
    {
        
        RuleFor(x=>x.Id)
            .NotNull()
            .NotEmpty()
            .Must(id=>teacherRepository.IsExists(id).GetAwaiter().GetResult())
            .WithMessage("id is not exists in our data");
        
        RuleFor(x => x.Name)
            .NotNull()
            .NotEmpty();

        RuleFor(x => x.Status)
        .NotEmpty()
        .NotNull();

        RuleFor(x => x.Password)
            .NotEmpty()
            .NotNull()
            .MinimumLength(8);


        RuleFor(x=>x.Email)
        .NotEmpty()
        .NotNull()
        .Must((request,email)=>teacherRepository.IsUnique(request.Id,"Email",email))
        .WithMessage("email should be unqiue in our data");

        
        RuleFor(x=>x.Image)
        .Must(id=>context.Images.Any(x=>x.Id==id))
        .WithMessage("image is not exists in our data")
        .When(request=>request.Image!=null);



    }

}