using Domain.Entities.Teacher.Teacher;
using FluentValidation;
using infrastructure;
using Repository.Teacher.Teacher;

namespace Admin.Teacher.Warning.Command.Add;

public class AddWarningValidation:AbstractValidator<AddWarningCommand>
{

    public AddWarningValidation(ApplicationDbContext context)
    {
        
        RuleFor(x => x.Reson)
            .NotEmpty()
            .WithMessage("reson should be not empty")
            .NotNull()
            .WithMessage("reson should be not null");
        
        RuleFor(x=>x.TeacherID)
            .NotEmpty()
            .NotNull()
            .Must(TeacherID=>context.Teachers.Any(x=>x.Id==TeacherID))
            .WithMessage("this teacher is not exists in our data");

        
    }
}