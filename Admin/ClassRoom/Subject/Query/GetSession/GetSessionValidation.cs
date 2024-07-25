using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;
using infrastructure;

namespace Admin.ClassRoom.Subject.Query.GetSession;

public class GetSessionValidation: AbstractValidator<GetSessionQuery>
{

    public GetSessionValidation(ApplicationDbContext context){

        RuleFor(x=>x.SubjectId)
        .NotEmpty()
        .NotNull()
        .Must(id=>context.Subjects.Any(x=>x.Id==id))
        .WithMessage("this subject is not exists in our data");

        RuleFor(x=>x.YearId)
        .Must((id)=>context.Years.Any(x=>x.Id==id))
        .When(x=>x.YearId.HasValue)
        .WithMessage("this year is not exsits in our data");

    }

}
