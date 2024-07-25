using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;
using infrastructure;
using Shared.Services.User;

namespace Teacher.Subject.Command.Add;

public class AddMarkToStudentValidation: AbstractValidator<AddMarkToStudentCommand>
{

    public AddMarkToStudentValidation(ApplicationDbContext context,ICurrentUserService currentUserService){

        RuleFor(x=>x.Mark)
        .NotNull()
        .GreaterThanOrEqualTo(0)
        .LessThanOrEqualTo(100);

        RuleFor(x=>x.StudentId)
        .NotEmpty()
        .NotNull()
        .Must((request,id)=>context.StudentSubjects.Any(x=>x.StudentId==id&&x.SubjectYear.TeacherId==currentUserService.GetUserid()&&x.SubjectYear.SubjectId==request.SubjectId))
        .WithMessage("you are not allowed to do this action");

    }

}
