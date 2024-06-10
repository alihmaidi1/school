using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;

namespace Student.Auth.Command.RefreshToken;
public class RefreshStudentTokenValidation: AbstractValidator<RefreshStudentTokenCommand>
{

    public RefreshStudentTokenValidation(){

        RuleFor(x=>x.RefreshToken)
        .NotEmpty()
        .NotNull();

    }

}
