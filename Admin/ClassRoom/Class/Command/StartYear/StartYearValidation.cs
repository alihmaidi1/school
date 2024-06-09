using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;
using infrastructure;

namespace Admin.ClassRoom.Class.Command.StartYear;

public class StartYearValidation: AbstractValidator<StartYearCommand>
{

    public StartYearValidation(ApplicationDbContext context){

        RuleFor(x=>x.ClassId)
        .NotEmpty()
        .NotNull();

        RuleFor(x=>x.YearId)
        .NotEmpty()
        .NotNull()
        .Must((request,id)=>!context.ClassYears.Any(x=>x.ClassId==request.ClassId&&x.YearId==id))
        .WithMessage("this year is already started");




    }

}
