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

        RuleFor(x=>x.StudentQuezId)
        .NotEmpty()
        .NotNull()
        .Must(id=>context.StudentQuezs.Any(x=>x.Id==id))
        .WithMessage("this id is not correct");

    }

}
