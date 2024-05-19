using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;
using infrastructure;

namespace Admin.ClassRoom.Subject.Query.Get;

public class GetSubjectDetailValidation: AbstractValidator<GetSubjectDetailQuery>
{

    public GetSubjectDetailValidation(ApplicationDbContext context){

        RuleFor(x=>x.YearId)
        .NotEmpty()
        .NotNull()
        .Must(id=>context.Years.Any(x=>x.Id==id))
        .WithMessage("this subject is not exists in our data");

    }

}
