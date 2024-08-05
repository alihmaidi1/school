using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;

namespace Student.Auth.Command.CheckResetCode;

public class CheckResetCodeValidation:AbstractValidator<CheckResetCodeCommand>
{


    public CheckResetCodeValidation(){


        RuleFor(x=>x.FcmToken)
        .NotEmpty()
        .NotNull();


        RuleFor(x=>x.Email)
        .NotEmpty()
        .NotNull();

        RuleFor(x=>x.Code)
        .NotEmpty()
        .NotNull();
    }
    

}
