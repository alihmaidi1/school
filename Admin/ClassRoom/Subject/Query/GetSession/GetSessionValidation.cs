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
        .NotNull();

        RuleFor(x=>x.YearId)
        .NotEmpty()
        .NotNull()
        .Must((request,yearid)=>context.SubjectYears.Any(x=>x.ClassYear.YearId==yearid&&x.TeacherSubject.SubjectId==request.SubjectId))
        .WithMessage("this subject not valid with this year");

    }

}
