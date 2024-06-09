using Domain.Entities.Role;
using FluentValidation;
using infrastructure;
using Repository.Manager.Role;

namespace Admin.Manager.Role.Command.Delete;

public class DeleteRoleCommandValidation:AbstractValidator<DeleteRoleCommand>
{
    
    public DeleteRoleCommandValidation(ApplicationDbContext context)
    {
        RuleFor(x => x.Id)
            .NotEmpty()
            .NotNull()
            .Must(Id => context.Roles.Any(x=>x.Id==Id&&!x.Admins.Any()))
            .WithMessage("id is not exists in our data or it have data");

    }
    
}