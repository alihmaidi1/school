using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;
using infrastructure;

namespace Admin.Teacher.VacationType.Command.Add;

public class AddVacationTypeValidation: AbstractValidator<AddVacationTypeCommand>
{

    public AddVacationTypeValidation(ApplicationDbContext context){

        RuleFor(x=>x.Name)
        .NotEmpty()
        .NotNull()
        .Must(name=>!context.VacationTypes.Any(x=>x.Name.Equals(name)))
        .WithMessage("this vacation type is already exists in our data");

    }
    
}
