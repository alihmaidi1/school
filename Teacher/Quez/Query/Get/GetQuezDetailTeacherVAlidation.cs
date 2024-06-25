using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities.Quez;
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
        .Must(id=>context.Quezs.Where(x=>x.SubjectYear.TeacherSubject.TeacherId==currentUserService.GetUserid()).Any(x=>x.Id==id&&x.EndAt<DateTimeOffset.UtcNow))
        .WithMessage("this quez is not exists or not belongs to you");
    }

}
