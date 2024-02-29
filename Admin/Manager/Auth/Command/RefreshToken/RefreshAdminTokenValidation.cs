using FluentValidation;
using Repository.Manager.RefreshToken;

namespace Admin.Auth.Command.RefreshToken;

public class RefreshAdminTokenValidation:AbstractValidator<RefreshAdminTokenCommand>
{


    public RefreshAdminTokenValidation(IAdminRefreshTokenRepository refreshTokenRepository)
    {
        
        
        RuleFor(x => x.RefreshToken)
            .NotEmpty()
            .WithMessage("refresh token can not be empty")
            .NotNull()
            .WithMessage("refresh token can not be null")
            .Must(x=>refreshTokenRepository.IsExists(x))
            .WithMessage("this refresh token is not valid");

        
    }
    
}