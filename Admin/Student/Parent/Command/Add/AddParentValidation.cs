using FluentValidation;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Repository.Student.Parent;
using Shared.Rule;

namespace Admin.Student.Parent.Command.Add;

public class AddParentValidation:AbstractValidator<AddParentCommand>
{
    
    public AddParentValidation(IParentRepository parentRepository,IWebHostEnvironment webHostEnvironment)
    {

        RuleFor(x => x.Name)
            .NotEmpty()
            .WithMessage("parent name should be not empty")
            .NotNull()
            .WithMessage("parent name should be not null");


        
        RuleFor(x => x.Email)
            .NotEmpty()
            .WithMessage("parent email should be not empty")
            .NotNull()
            .WithMessage("parent email should be not null")
            .Must(Email=>!parentRepository.IsExists(Email))
            .WithMessage("this email was already exists in our data");

        
        
        RuleFor(x => x.Password)
            .NotEmpty()
            .WithMessage("parent password should be not empty")
            .NotNull()
            .WithMessage("parent password should be not null")
            .MinimumLength(8)
            .WithMessage("password length should be at least 8 charecter");

        RuleFor(x => x.Url)
            .Must(url=>FileRule.IsFileExists(url,webHostEnvironment.WebRootPath));


    }

    
}