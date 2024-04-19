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
            .EmailAddress()
            .Must(email=>adminRepository.IsExistsByProperty("Email",email))
            .WithMessage("email is not found in our data");

        RuleFor(x => x.Password)
            .NotEmpty()
            .NotNull()
            .MinimumLength(8);




    }


}