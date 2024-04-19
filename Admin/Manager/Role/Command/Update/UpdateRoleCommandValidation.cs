using Domain.Entities.Role;
using Domain.Enum;
using FluentValidation;
using Repository.Manager.Role;

namespace Admin.Manager.Role.Command.Update;

public class UpdateRoleCommandValidation:AbstractValidator<UpdateRoleCommand>
{
    
    
    public UpdateRoleCommandValidation(IRoleRepository roleRepository)
    {
        RuleFor(x => x.Id)
            .NotEmpty()
            .NotNull()
            .Must(Id => roleRepository.IsExists(Id).GetAwaiter().GetResult())
            .WithMessage("id is not exists in our data");
        

        RuleFor(x=>x.Name)
        .NotNull()
        .NotEmpty()
        .Must((request,name)=>roleRepository.IsUnique(request.Id,"Name",name))
        .WithMessage("this role is already exists");
        

    
        RuleForEach(x => x.Permissions)
            .NotEmpty()
            .NotNull()
            .Must(x => Enum.GetNames(typeof(PermissionEnum)).Any(permission => permission.Equals(x)))
            .WithMessage("this permission is not exists");
    }
}