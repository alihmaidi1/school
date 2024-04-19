using FluentValidation;

namespace Admin.Manager.Auth.Command.RefreshToken;

public class RefreshAdminTokenValidation:AbstractValidator<RefreshAdminTokenCommand>
{


    public RefreshAdminTokenValidation()
    {


        RuleFor(x => x.RefreshToken)
            .NotEmpty()
            .NotNull();


    }
    
}