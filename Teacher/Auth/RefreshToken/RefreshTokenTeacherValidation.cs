using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;

namespace Teacher.Auth.RefreshToken;

public class RefreshTokenTeacherValidation: AbstractValidator<RefreshTokenTeacherCommand>
{

    public RefreshTokenTeacherValidation(){


        RuleFor(x=>x.RefreshToken)
        .NotEmpty()
        .NotNull();
    }

}
