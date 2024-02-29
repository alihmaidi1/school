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
            .WithMessage("id should be not empty")
            .NotNull()
            .WithMessage("id should be not null")
            .Must(Id => roleRepository.IsExists(new RoleID(Id)))
            .WithMessage("id is not exists in our data");


        RuleFor(x => x.OrderBy)
            .Must(x => CrudOpterationRule.IsValidOrder(x, AdminSorting.OrderBy))
            .WithMessage("order by string is not valid");
    }
}