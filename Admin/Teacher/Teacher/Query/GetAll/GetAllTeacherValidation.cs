using Common.ExtensionMethod;
using FluentValidation;
using Repository.Teacher.Teacher;

namespace Admin.Teacher.Teacher.Query.GetAll;

public class GetAllTeacherValidation:AbstractValidator<GetAllTeacherQuery>
{
    
    
    public GetAllTeacherValidation()
    {
        
        RuleFor(x => x.OrderBy)
            .Must(x => CrudOpterationRule.IsValidOrder(x, TeacherSorting.OrderBy))
            .WithMessage("order by string is not valid");

        
        
    }


    
}