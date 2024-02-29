using FluentValidation;
using Repository.Manager.Role;
using Shared.Rule;

namespace Admin.Manager.Role.Query.GetAll;

public class GetRolesValidation:AbstractValidator<GetRolesQuery>
{
    
    public GetRolesValidation()
    {
        RuleFor(x => x.OrderBy)
            .Must(x => CrudOpterationRule.IsValidOrder(x, RoleSorting.OrderBy))
            .WithMessage("order by string is not valid");
    }
}