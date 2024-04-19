using Common.ExtensionMethod;
using FluentValidation;
using Repository.Student.Parent;

namespace Admin.Student.Parent.Query.GetAll;

public class GetAllParentValidation:AbstractValidator<GetAllParentsQuery>
{
    
    
    public GetAllParentValidation()
    {
        

        RuleFor(x => x.OrderBy)
            .Must(x => CrudOpterationRule.IsValidOrder(x, ParentSorting.OrderBy))
            .WithMessage("order by string is not valid");

        
    }
    
}