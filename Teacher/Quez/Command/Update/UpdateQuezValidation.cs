using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;
using infrastructure;

namespace Teacher.Quez.Command.Update;

public class UpdateQuezValidation: AbstractValidator<UpdateQuezCommand>
{

    public UpdateQuezValidation(ApplicationDbContext context){


        RuleFor(x=>x.Id)
        .NotEmpty()
        .NotNull()
        .Must(id=>context.Quezs.Any(x=>x.Id==id&&x.StartAt> DateTimeOffset.UtcNow))
        .WithMessage("this quez is not exists or it is active or finished");

        RuleFor(x=>x.Name)
        .NotEmpty()
        .NotNull();

        RuleFor(x=>x.StartAt)
        .NotEmpty()
        .NotNull()
        .GreaterThan(DateTimeOffset.UtcNow);

    }

}
