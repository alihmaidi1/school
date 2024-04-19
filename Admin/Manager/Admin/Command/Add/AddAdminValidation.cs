using FluentValidation;
using Repository.Manager.Admin;
using Repository.Manager.Role;

namespace Admin.Manager.Admin.Command.Add;

public class AddAdminValidation:AbstractValidator<AddAdminCommand>
{

    public AddAdminValidation(IAdminRepository adminRepository,IRoleRepository roleRepository)
    {
        
        RuleFor(x => x.Name)
            .NotEmpty()
            .NotNull();
        
        
        RuleFor(x => x.RoleId)
            .NotEmpty()
            .NotNull()
            .Must(id => roleRepository.IsExists(id).GetAwaiter().GetResult())
            .WithMessage("this role is not valid");

        RuleFor(x => x.Password)
            .NotEmpty()
            .NotNull()
            .MinimumLength(8);


        RuleFor(x => x.Email)
            .NotEmpty()
            .NotNull()
            .EmailAddress()
            .Must(email => !adminRepository.IsExistsByProperty("Email",email))
            .WithMessage("email address is already exists");

        RuleFor(x => x.ImageId)
            .NotNull()
            .NotEmpty();
    }
    
}