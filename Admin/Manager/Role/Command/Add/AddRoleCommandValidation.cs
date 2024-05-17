using Domain.Enum;
using FluentValidation;
using Repository.Manager.Role;

namespace Admin.Manager.Role.Command.Add;

public class AddRoleCommandValidation:AbstractValidator<AddRoleCommand>
{
    
    public AddRoleCommandValidation(IRoleRepository roleRepository)
    {
        RuleFor(x => x.Name)
            .NotEmpty()
            .NotNull()
            .Must(name => !roleRepository.IsExistsByProperty("Name",name))
            .WithMessage("this role is already exists");


        RuleForEach(x => x.Permissions)
            .NotEmpty()
            .WithMessage("permission should be not empty")
            .NotNull()
            .WithMessage("permission should be not null")
            .Must(x => Enum.GetNames(typeof(PermissionEnum)).Any(permission => permission.Equals(x)))
            .WithMessage("this permission is not exists");
    }
    
}