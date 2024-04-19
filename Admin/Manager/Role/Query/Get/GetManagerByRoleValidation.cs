using Common.ExtensionMethod;
using Domain.Entities.Role;
using FluentValidation;
using Repository.Manager.Admin;
using Repository.Manager.Role;

namespace Admin.Manager.Role.Query.Get;

public class GetManagerByRoleValidation:AbstractValidator<GetManagerByRoleQuery>
{
    
    public GetManagerByRoleValidation(IRoleRepository roleRepository)
    {
        RuleFor(x => x.Id)
            .NotEmpty()
            .NotNull()
            .Must(Id => roleRepository.IsExists(Id).GetAwaiter().GetResult())
            .WithMessage("id is not exists in our data");

    }
}