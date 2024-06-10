using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;
using infrastructure;

namespace Student.Subject.Query.GetAllQuez;

public class GetAllQuezValidation: AbstractValidator<GetAllQuezQuery>
{

    public GetAllQuezValidation(ApplicationDbContext context){


        RuleFor(x=>x.SubjectYearId)
        .NotEmpty()
        .NotNull()
        .Must(id=>context.SubjectYears.Any(x=>x.Id==id))
        .WithMessage("this subject not exists in this year");

    }

}
