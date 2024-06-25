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
        .NotNull()
        .Must(startAt=>startAt>=DateTimeOffset.UtcNow);


        RuleFor(x=>x.SubjectId)
        .NotNull()
        .NotEmpty()
        .Must(id=>context.SubjectYears.Any(x=>x.ClassYear.Status&&x.TeacherSubject.SubjectId==id&&x.TeacherSubject.TeacherId==currentUserService.GetUserid()))
        .WithMessage("this subject is not exists or in active year");


        RuleFor(x=>x.EndAt)
        .NotEmpty()
        .NotNull()
        .GreaterThan(x=>x.StartAt);
    }

}
