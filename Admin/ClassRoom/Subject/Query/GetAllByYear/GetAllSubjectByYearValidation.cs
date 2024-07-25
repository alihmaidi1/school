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
        .Must(id=>context.Years.Any(x=>x.Id==id))
        .When(x=>x.YearId.HasValue)
        .WithMessage("this year is not exists in our data");

     
    }

}
