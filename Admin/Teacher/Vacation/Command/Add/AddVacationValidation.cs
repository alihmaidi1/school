using Domain.Entities.Teacher.Teacher;
using FluentValidation;
using Repository.Teacher.Teacher;

namespace Admin.Teacher.Vacation.Command.Add;

public class AddVacationValidation:AbstractValidator<AddVacationCommand>
{
    public AddVacationValidation(ITeacherRepository teacherRepository)
    {

        RuleFor(x => x.Reason)
            .NotEmpty()
            .WithMessage("reason should be not empty")
            .NotNull()
            .WithMessage("reason should be not null");


    }

}