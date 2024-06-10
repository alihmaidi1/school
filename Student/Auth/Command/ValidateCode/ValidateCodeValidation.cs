using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;
using infrastructure;

namespace Student.Auth.Command.ValidateCode;

public class ValidateCodeValidation: AbstractValidator<ValidateCodeCommand>
{

    public ValidateCodeValidation(ApplicationDbContext context){

        RuleFor(x=>x.Email)
        .NotEmpty()
        .NotNull()
        .EmailAddress()
        .Must(email=>context.Students.Any(x=>x.Email==email))
        .WithMessage("this email is not exists in our data");

        RuleFor(x=>x.Code)
        .NotEmpty()
        .NotNull()
        .Length(6);

    }

}
