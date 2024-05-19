using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;
using infrastructure;

namespace Admin.ClassRoom.Subject.Query.GetAllByYear;

public class GetAllSubjectByYearValidation:AbstractValidator<GetAllSubjectByYearQuery>
{

    public GetAllSubjectByYearValidation(ApplicationDbContext context){


        RuleFor(x=>x.YearId)
        .NotEmpty()
        .NotNull()
        .Must(id=>context.Years.Any(x=>x.Id==id))
        .WithMessage("this year id is not exists in our data");

    }

}
