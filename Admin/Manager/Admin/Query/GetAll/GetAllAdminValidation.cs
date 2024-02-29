using FluentValidation;
using Repository.Manager.Admin;
using Shared.Rule;

namespace Admin.Admin.Query.GetAll;

public class GetAllAdminValidation:AbstractValidator<GetAllAdminQuery>
{
    
    
    public GetAllAdminValidation()
    {
        RuleFor(x => x.OrderBy)
            .Must(x => CrudOpterationRule.IsValidOrder(x, AdminSorting.OrderBy))
            .WithMessage("order by string is not valid");
    }
    
}