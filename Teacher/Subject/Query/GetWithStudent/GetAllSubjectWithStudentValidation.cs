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
        .NotEmpty()
        .NotNull()
        .Must(id=>context.Years.Any(x=>x.Id==id))
        .WithMessage("this year is not exists in our data");
    }

}
