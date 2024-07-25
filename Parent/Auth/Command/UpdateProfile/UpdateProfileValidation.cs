using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;
using infrastructure;
using Shared.Services.User;

namespace Parent.Auth.Command.UpdateProfile;

public class UpdateProfileValidation: AbstractValidator<UpdateProfileCommand>
{

    public UpdateProfileValidation(ApplicationDbContext context,ICurrentUserService currentUserService){


        RuleFor(x=>x.Email)
        .NotEmpty()
        .NotNull()
        .Must(email=>!context.Parents.Any(x=>x.Email==email&&x.Id!=currentUserService.GetUserid()))
        .WithMessage("this email is already exists in our data");

        RuleFor(x=>x.Name)
        .NotEmpty()
        .NotNull();

        RuleFor(x=>x.Password)
        .MinimumLength(8)
        .When(x=>x.Password!=null);







    }

}
