using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;
using infrastructure;
using Shared.Services.User;

namespace Teacher.Quez.Query.Get;

public class GetQuezDetailTeacherVAlidation: AbstractValidator<GetQuezDetailQuery>
{

    public GetQuezDetailTeacherVAlidation(ApplicationDbContext context,ICurrentUserService currentUserService){

        RuleFor(x=>x.Id)
        .NotEmpty()
        .NotNull()
        .Must(id=>context.Quezs.Any(x=>x.Id==id&&x.IsBelongForId((Guid)currentUserService.UserId!)&&x.IsFinished()))
        .WithMessage("this quez is not exists or not belongs to you");
    }

}
