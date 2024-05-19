using Domain.Entities.Teacher.Vacation;
using FluentValidation;
using infrastructure;
using Repository.Teacher.Vacation;

namespace Admin.Teacher.Vacation.Command.ChangeStatus;

public class ChangeVacationStatusValidation:AbstractValidator<ChnageVacationStatusCommand>
{

    public ChangeVacationStatusValidation(ApplicationDbContext context)
    {

        RuleFor(x => x.Id)
            .NotEmpty()
            .NotNull()
            .Must(id => context.Vacations.Any(x=>x.Id==id))
            .WithMessage("this id is not exists in our data");
        //
        //
        RuleFor(x => x.Status)
            .NotNull();

    }
    
}