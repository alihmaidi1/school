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
            .NotNull()
            .Must(Id => roleRepository.IsExists(Id).GetAwaiter().GetResult())
            .WithMessage("id is not exists in our data");

    }
    
}