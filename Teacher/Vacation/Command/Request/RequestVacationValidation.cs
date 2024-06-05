using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;
using infrastructure;

namespace Teacher.Vacation.Command.Request;

public class RequestVacationValidation: AbstractValidator<RequestVacationCommand>
{

    public RequestVacationValidation(ApplicationDbContext context){



        RuleFor(x=>x.Reason)
        .NotEmpty()
        .NotNull();

        RuleFor(x=>x.StartAt)
        .NotEmpty()
        .NotNull()
        .GreaterThan(DateTimeOffset.UtcNow);


        RuleFor(x=>x.TypeId)
        .NotEmpty()
        .NotNull()
        .Must(id=>context.VacationTypes.Any(x=>x.Id==id))
        .WithMessage("id is not exists in our data");


        RuleFor(x=>x.Period)
        .NotEmpty()
        .NotNull()
        .GreaterThan(0);
    }


}
