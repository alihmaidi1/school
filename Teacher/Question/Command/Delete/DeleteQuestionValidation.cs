using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;
using infrastructure;
using Org.BouncyCastle.Math.EC.Rfc7748;
using Shared.Services.User;

namespace Teacher.Question.Command.Delete;

public class DeleteQuestionValidation:AbstractValidator<DeleteQuestionCommand>
{

    public DeleteQuestionValidation(ApplicationDbContext context,ICurrentUserService currentUserService){

        RuleFor(x=>x.Id)
        .NotEmpty()
        .NotNull()
        .Must(id=>context.Questions.Any(x=>x.Id==id&&x.Quez.StartAt>DateTimeOffset.UtcNow&&x.Quez.SubjectYear.TeacherSubject.TeacherId==currentUserService.UserId))
        .WithMessage("this quez is active or not belongs to you");
    }

}
