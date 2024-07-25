using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;
using infrastructure;

namespace Teacher.Leson.Teacher.Leson.Query.GetAllLeson;

public class GetAllTeacherLesonValidation: AbstractValidator<GetAllLesonQuery>
{


    public GetAllTeacherLesonValidation(ApplicationDbContext context){


        

        RuleFor(x=>x.YearId)
        .Must(id=>context.Years.Any(x=>x.Id==id))
        .When(x=>x.YearId.HasValue)
        .WithMessage("this year is not exists or teacher is not learning in this year");
    }



}
