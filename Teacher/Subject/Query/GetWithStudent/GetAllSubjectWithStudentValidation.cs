using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;
using infrastructure;

namespace Teacher.Subject.Query.GetWithStudent;

public class GetAllSubjectWithStudentValidation: AbstractValidator<GetAllSubjectWithStudentQuery>
{

    public GetAllSubjectWithStudentValidation(ApplicationDbContext context){

        RuleFor(x=>x.YearId)
        .Must(id=>context.Years.Any(x=>x.Id==id))
        .When(x=>x.YearId.HasValue)
        .WithMessage("this year is not exists in our data");
    }

}
