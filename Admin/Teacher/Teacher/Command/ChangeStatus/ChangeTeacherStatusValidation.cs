using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;
using infrastructure;

namespace Admin.Teacher.Teacher.Command.ChangeStatus;

public class ChangeTeacherStatusValidation: AbstractValidator<ChangeTeacherStatusCommand>
{

    public ChangeTeacherStatusValidation(ApplicationDbContext context){



        RuleFor(x=>x.Id)
        .NotEmpty()
        .NotNull()
        .Must(id=>context.Teachers.Any(x=>x.Id==id))
        .WithMessage("teacher is not exists in our data");


        RuleFor(x=>x.Reason)
        .NotNull()
        .When(x=>!x.Status);

    }

}
