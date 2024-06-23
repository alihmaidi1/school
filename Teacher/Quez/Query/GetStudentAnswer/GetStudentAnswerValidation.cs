using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;
using infrastructure;
using Shared.Services.User;

namespace Teacher.Quez.Query.GetStudentAnswer;

public class GetStudentAnswerValidation: AbstractValidator<GetStudentAnswerQuery>
{

    public GetStudentAnswerValidation(ApplicationDbContext context,ICurrentUserService currentUserService){

        RuleFor(x=>x.QuezId)
        .NotEmpty()
        .NotNull()
        .Must(id=>context.Quezs.Any(x=>x.Id==id&&x.SubjectYear.TeacherSubject.TeacherId==currentUserService.GetUserid()))
        .WithMessage("this quez is not belongs to you");

        RuleFor(x=>x.StudentId)
        .NotEmpty()
        .NotNull()
        .Must((request,id)=>context.StudentQuezs.Any(x=>x.StudentId==id&&x.QuezId==request.QuezId))
        .WithMessage("this student does not have this quez");
    }

}
