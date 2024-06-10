using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;
using infrastructure;

namespace Student.Subject.Query.GetAllLeson;

public class GetAllLesonValidation: AbstractValidator<GetAllLesonQuery>
{

    public GetAllLesonValidation(ApplicationDbContext context){

        RuleFor(x=>x.SubjectYearId)
        .NotEmpty()
        .NotNull()
        .Must(id=>context.SubjectYears.Any(x=>x.Id==id))
        .WithMessage("subject in this year is not exists in our data");

    }

}
