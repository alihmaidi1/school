using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;
using infrastructure;

namespace Teacher.Subject.Query.GetAllAudience;

public class GetAllAudienceValidation: AbstractValidator<GetAllAudienceQuery>
{



    public GetAllAudienceValidation(ApplicationDbContext context){


        RuleFor(x=>x.YearId)
        .NotEmpty()
        .NotNull()
        .Must(id=>context.Years.Any(x=>x.Id==id))
        .WithMessage("this year is not exists in our data");


        RuleFor(x=>x.SubjectId)
        .NotEmpty()
        .NotNull()
        .Must((request,id)=>context.SubjectYears.AsNoTracking().Any(x=>x.SubjectId==id&&x.ClassYear.YearId==request.YearId))
        .WithMessage("this subject or year is not exists in our data");


    }

}
