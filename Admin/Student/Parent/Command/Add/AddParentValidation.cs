using FluentValidation;
using infrastructure;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Identity.Client;
using Shared.Rule;

namespace Admin.Student.Parent.Command.Add;

public class AddParentValidation:AbstractValidator<AddParentCommand>
{
    
    public AddParentValidation(ApplicationDbContext context)
    {

        RuleFor(x => x.Name)
            .NotEmpty()
            .NotNull();


        
        RuleFor(x => x.Email)
            .NotEmpty()
            .NotNull()
            .EmailAddress()
            .Must(Email=>!context.Parents.Any(x=>x.Email.Equals(Email)))
            .WithMessage("this email was already exists in our data");

        
        
        RuleFor(x => x.Password)
            .NotEmpty()
            .NotNull()
            .MinimumLength(8);


        RuleFor(x=>x.Image)
        .NotEmpty()
        .NotNull()
        .Must(id=>context.Images.Any(x=>x.Id==id))
        .WithMessage("this image is not exists in our data");


    }

    
}