using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;
using infrastructure;

namespace Admin.ClassRoom.Class.Command.FinishYear;

public class FinishYearValidation: AbstractValidator<FinishYearCommand>
{

    public FinishYearValidation(ApplicationDbContext context){

        RuleFor(x=>x.ClassYearId)
        .NotEmpty()
        .NotNull()
        .Must(id=>context.ClassYears.Any(x=>x.Id==id&&!x.Status))
        .WithMessage("this class year is not exists or is already finished");

    }

}
