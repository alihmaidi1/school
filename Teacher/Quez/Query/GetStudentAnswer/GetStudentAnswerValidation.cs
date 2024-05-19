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
        .Must(id=>context.Quezs.Any(x=>x.Id==id&&x.IsBelongForId((Guid)currentUserService.UserId!)))
        .WithMessage("this quez is not belongs to you");

        RuleFor(x=>x.StudentId)
        .NotEmpty()
        .NotNull()
        .Must((request,id)=>context.Students.Where(x=>x.Id==id).Any(x=>x.StudentSubjects.Any(y=>y.StudentQuezs.Any(z=>z.QuezId==request.QuezId))))
        .WithMessage("this student does not have this quez");
    }

}
