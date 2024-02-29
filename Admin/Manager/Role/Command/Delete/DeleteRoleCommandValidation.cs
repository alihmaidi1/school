using Domain.Entities.Role;
using FluentValidation;
using Repository.Manager.Role;

namespace Admin.Manager.Role.Command.Delete;

public class DeleteRoleCommandValidation:AbstractValidator<DeleteRoleCommand>
{
    
    public DeleteRoleCommandValidation(IRoleRepository roleRepository)
    {
        RuleFor(x => x.Id)
            .NotEmpty()
            .WithMessage("id should be not empty")
            .NotNull()
            .WithMessage("id should be not null")
            .Must(Id => roleRepository.IsExists(new RoleID(Id)))
            .WithMessage("id is not exists in our data");
    }
    
}