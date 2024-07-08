using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;
using infrastructure;

namespace Parent.Auth.Command.ReSetCode;

public class ResetCodeValidation: AbstractValidator<ResetCodeCommand>
{

    public ResetCodeValidation(ApplicationDbContext context){

        RuleFor(x=>x.Email)
        .NotEmpty()
        .NotNull()
        .Must(email=>context.Parents.Any(x=>x.Email==email))
        .WithMessage("this email is not exists in our data");

    }

}
