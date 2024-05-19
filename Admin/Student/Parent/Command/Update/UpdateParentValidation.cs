using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;
using infrastructure;

namespace Admin.Student.Parent.Command.Update;

public class UpdateParentValidation: AbstractValidator<UpdateParentCommand>
{

    public UpdateParentValidation(ApplicationDbContext context){


        RuleFor(x=>x.Id)
        .NotEmpty()
        .NotNull()
        .Must(id=>context.Parents.Any(x=>x.Id==id))
        .WithMessage("this parent is not exists in our data");
            
        RuleFor(x=>x.Name)
        .NotEmpty()
        .NotNull();

        RuleFor(x=>x.Email)
        .NotEmpty()
        .NotNull()
        .Must((request,email)=>!context.Parents.Any(x=>x.Id!=request.Id&&x.Email==email))
        .WithMessage("this email is already exists in our data");

        

        RuleFor(x => x.Password)
        .NotEmpty()
        .NotNull()
        .MinimumLength(8);


        RuleFor(x=>x.Image)
        .NotEmpty()
        .NotNull()
        .Must(id=>context.Images.Any(x=>x.Id==id))
        .When(x=>x.Image!=null)
        .WithMessage("this image is not exists in our data");


    }

}
