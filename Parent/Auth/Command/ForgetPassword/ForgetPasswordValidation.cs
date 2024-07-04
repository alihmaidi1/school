using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;
using infrastructure;

namespace Parent.Auth.Command.ForgetPassword;

public class ForgetPasswordValidation: AbstractValidator<ForgetPasswordCommand>
{

    public ForgetPasswordValidation(ApplicationDbContext context){


        RuleFor(x=>x.Email)
        .NotEmpty()
        .NotNull()
        .Must(email=>context.Parents.Where(x=>x.Status).Any(x=>x.Email==email))
        .WithMessage("this email is not correct");


    }

}
