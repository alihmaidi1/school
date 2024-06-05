using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;
using infrastructure;

namespace Admin.Teacher.VacationType.Command.Delete;

public class DeleteVacaionTypeValidation: AbstractValidator<DeleteVacationTypeCommand>
{

    public DeleteVacaionTypeValidation(ApplicationDbContext context){


        RuleFor(x=>x.Id)
        .NotEmpty()
        .NotNull()
        .Must(id=>context.VacationTypes.Any(x=>x.Id==id&&!x.Vacations.Any()))
        .WithMessage("this vacation type is not exists or have vacation data");

    }

}
