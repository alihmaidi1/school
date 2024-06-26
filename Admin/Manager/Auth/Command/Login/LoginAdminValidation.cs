using FluentValidation;
using Repository.Manager.Admin;

namespace Admin.Manager.Auth.Command.Login;

public class LoginAdminValidation:AbstractValidator<LoginAdminCommand>
{

    public LoginAdminValidation(IAdminRepository adminRepository)
    {

        RuleFor(x => x.Email)
            .NotEmpty()
            .NotNull()
            .EmailAddress();

        RuleFor(x => x.Password)
            .NotEmpty()
            .NotNull()
            .MinimumLength(8);

        RuleFor(x=>x.FcmToken)
        .NotEmpty()
        .NotNull();


    }


}