using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;

namespace Student.Auth.Command.Login;

public class LoginStudentValidation: AbstractValidator<LoginStudentCommand>
{

    public LoginStudentValidation(){


        RuleFor(x=>x.Email)
        .NotEmpty()
        .NotNull()
        .EmailAddress();

        RuleFor(x=>x.Password)
        .NotEmpty()
        .NotNull();

    }

}
