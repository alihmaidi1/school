using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;

namespace Parent.Auth.Command.Login;

public class LoginParentValidation: AbstractValidator<LoginParentCommand>
{

    public LoginParentValidation(){


        RuleFor(x=>x.Email)
        .NotEmpty()
        .NotNull()
        .EmailAddress();

        RuleFor(x=>x.Password)
        .NotEmpty()
        .NotNull();

    }

}
