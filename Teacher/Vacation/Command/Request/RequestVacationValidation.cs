using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;

namespace Teacher.Vacation.Command.Request;

public class RequestVacationValidation: AbstractValidator<RequestVacationCommand>
{

    public RequestVacationValidation(){


        RuleFor(x=>x.Reason)
        .NotEmpty()
        .NotNull();

        RuleFor(x=>x.StartAt)
        .NotEmpty()
        .NotNull()
        .GreaterThan(DateTime.Now);

        RuleFor(x=>x.type)
        .IsInEnum();

        RuleFor(x=>x.Period)
        .NotEmpty()
        .NotNull()
        .GreaterThan(0);
    }


}
