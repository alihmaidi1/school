using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;
using infrastructure;
using Org.BouncyCastle.Ocsp;

namespace Admin.ClassRoom.Class.Command.StartYear;

public class StartYearValidation: AbstractValidator<StartYearCommand>
{

    public StartYearValidation(ApplicationDbContext context){

        RuleFor(x=>x.ClassId)
        .NotEmpty()
        .NotNull()
        .Must(id=>!context.ClassYears.Any(x=>x.ClassId==id&&x.Status))
        .WithMessage("last year is not finished yet")
        .Must(id=>!context.ClassYears.Any(x=>x.ClassId==id&&x.Year.Date.Year==DateTime.UtcNow.Year))
        .WithMessage("this class in this year is already created");

        // RuleFor(x=>x.YearId)
        // .NotEmpty()
        // .NotNull()
        // .Must((request,id)=>!context.ClassYears.Any(x=>x.ClassId==request.ClassId&&x.YearId==id))
        // .WithMessage("this year is already started");




    }

}
