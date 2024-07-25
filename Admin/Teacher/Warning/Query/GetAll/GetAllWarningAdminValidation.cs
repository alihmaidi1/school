using Domain.Entities.Teacher.Teacher;
using FluentValidation;
using infrastructure;
using Repository.Teacher.Teacher;

namespace Admin.Teacher.Warning.Query.GetAll;

public class GetAllWarningAdminValidation:AbstractValidator<GetAllWarningAdminQuery>
{

    public GetAllWarningAdminValidation(ApplicationDbContext context)
    {
        RuleFor(x => x.TeacherId)
            .Must(id => context.Teachers.Any(x=>x.Id==id));
        
        // RuleFor(x => x.Date)
        //     .LessThanOrEqualTo(DateTime.Now.Year)
        //     .When(x => x.Date!=null)
        //     .GreaterThan(0)
        //     .When(x=>x.Date!=null);
    }
    
}