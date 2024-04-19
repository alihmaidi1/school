using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;
using infrastructure;
using Shared.Rule;

namespace Teacher.Leson.Command.Add;

public class AddLesonValidation: AbstractValidator<AddLesonCommand>
{

    public AddLesonValidation(ApplicationDbContext context){


        RuleFor(x=>x.Name)
        .NotEmpty()
        .NotNull();


        RuleFor(x=>x.File)
        .NotEmpty()
        .NotNull()
        .Must(file=>FileRule.IsPDF(file))
        .WithMessage("file should be pdf");
    
    
        RuleFor(x=>x.SubjectId)
        .NotNull()
        .NotEmpty()
        .Must(id=>context.Subjects.Any(x=>x.Id==id))
        .WithMessage("this subject is not exists in our data");
        
    }


}
