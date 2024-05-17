using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;
using infrastructure;
using Shared.Services.User;

namespace Teacher.Quez.Command.Add;

public class AddQuezValidation: AbstractValidator<AddQuezCommand>
{

    public AddQuezValidation(ApplicationDbContext context,ICurrentUserService currentUserService){


        RuleFor(x=>x.Name)
        .NotEmpty()
        .NotNull();



        RuleFor(x=>x.StartAt)
        .NotEmpty()
        .NotNull();


        RuleFor(x=>x.SubjectId)
        .NotEmpty()
        .NotNull()
        .Must(id=>context.SubjectYears.Any(x=>x.SubjectId==id&& x.TeacherId==currentUserService.UserId&&x.Year.Date.Year==DateTime.Now.Year))
        .WithMessage("this subject is not belongs to this teacher in this year");
    }

}
