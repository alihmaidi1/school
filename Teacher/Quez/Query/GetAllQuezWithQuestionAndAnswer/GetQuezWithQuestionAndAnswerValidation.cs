using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Azure.Core;
using FluentValidation;
using infrastructure;
using Org.BouncyCastle.Ocsp;
using Shared.Services.User;

namespace Teacher.Quez.Query.GetAllQuezWithQuestionAndAnswer;

public class GetQuezWithQuestionAndAnswerValidation:AbstractValidator<GetQuezWithQuestionAndAnswerQuery>
{

    

    public GetQuezWithQuestionAndAnswerValidation(ApplicationDbContext context,ICurrentUserService currentUserService){

        RuleFor(x=>x.Id)
        .NotEmpty()
        .NotNull()
        .Must(id=>context.Quezs.Any(x=>x.Id==id&&x.SubjectYear.TeacherSubject.TeacherId==currentUserService.UserId))
        .WithMessage("this quez is not belongs to you");

    }

}
