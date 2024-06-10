using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;

namespace Parent.Auth.Command.RefreshToken;
public class RefreshParentTokenValidation: AbstractValidator<RefreshParentTokenCommand>
{

    public RefreshParentTokenValidation(){

        RuleFor(x=>x.RefreshToken)
        .NotEmpty()
        .NotNull();

    }

}
