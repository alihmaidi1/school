using Domain.Entities.Teacher.Vacation;
using FluentValidation;
using Repository.Teacher.Vacation;

namespace Admin.Teacher.Vacation.Command.ChangeStatus;

public class ChangeVacationStatusValidation:AbstractValidator<ChnageVacationStatusCommand>
{

    public ChangeVacationStatusValidation(IVacationRepository vacationRepository)
    {

        RuleFor(x => x.Id)
            .NotEmpty()
            .NotNull()
            .Must(x => vacationRepository.IsExists(new VacationID(x)))
            .WithMessage("this id is not exists in our data");
        
        
        RuleFor(x => x.Status)
            .NotEmpty()
            .NotNull();

    }
    
}