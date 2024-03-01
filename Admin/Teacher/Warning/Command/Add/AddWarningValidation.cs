using Domain.Entities.Teacher.Teacher;
using FluentValidation;
using Repository.Teacher.Teacher;

namespace Admin.Teacher.Warning.Command.Add;

public class AddWarningValidation:AbstractValidator<AddWarningCommand>
{

    public AddWarningValidation(ITeacherRepository teacherRepository)
    {
        
        RuleFor(x => x.Reson)
            .NotEmpty()
            .WithMessage("reson should be not empty")
            .NotNull()
            .WithMessage("reson should be not null");

        RuleFor(x=>x.TeacherID)
            .NotEmpty()
            .WithMessage("Teacher id should be not empty")
            .NotNull()
            .WithMessage("Teacher id should be not null")
            .Must(TeacherID=>teacherRepository.IsExists(new TeacherID(TeacherID)))
            .WithMessage("this teacher is not exists in our data");

        
    }
}