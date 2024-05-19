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
        .Must(id=>context.Questions.Any(x=>x.Id==id&&x.Quez.IsPending()&&x.Quez.IsBelongForId((Guid)currentUserService.UserId!)));
    }

}
