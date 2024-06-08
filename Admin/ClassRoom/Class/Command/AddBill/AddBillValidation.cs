using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;
using infrastructure;

namespace Admin.ClassRoom.Class.Command.AddBill;

public class AddBillValidation: AbstractValidator<AddBillCommand>
{

    public AddBillValidation(ApplicationDbContext context){


        RuleFor(x=>x.Id)
        .NotEmpty()
        .NotNull()
        .Must(id=>context.ClassYears.Any(x=>x.Status&&x.ClassId==id))
        .WithMessage("this class is not exists or not active");        


        RuleFor(x=>x.Date)
        .NotEmpty()
        .NotNull()
        .GreaterThan(DateTimeOffset.UtcNow);

        RuleFor(x=>x.Money)
        .NotEmpty()
        .NotNull()
        .GreaterThan(0);


    }

}
