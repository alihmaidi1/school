using Domain.Entities.Teacher.Teacher;
using FluentValidation;
using Repository.Teacher.Teacher;

namespace Admin.Teacher.Warning.Query.GetAll;

public class GetAllWarningAdminValidation:AbstractValidator<GetAllWarningAdminQuery>
{

    public GetAllWarningAdminValidation(ITeacherRepository teacherRepository)
    {
        // RuleFor(x => x.TeacherId)
        //     .Must(x => teacherRepository.IsExists(new TeacherID((Guid)x)))
        //     .When(x=>x.TeacherId!=null);
        //
        // RuleFor(x => x.Date)
        //     .LessThanOrEqualTo(DateTime.Now.Year)
        //     .When(x => x.Date!=null)
        //     .GreaterThan(0)
        //     .When(x=>x.Date!=null);
    }
    
}