using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;
using infrastructure;

namespace Teacher.Subject.Query.GetAllAudience;

public class GetAllAudienceValidation: AbstractValidator<GetAllAudienceQuery>
{



    public GetAllAudienceValidation(ApplicationDbContext context){


        // RuleFor(x=>x.YearId)
        // .NotEmpty()
        // .NotNull();


        // RuleFor(x=>x.SubjectId)
        // .NotEmpty()
        // .NotNull()
        // .Must((request,id)=>context.SubjectYears.Any(x=>x.SubjectId==id&&x.YearId==request.YearId))
        // .WithMessage("this subject or year is not exists in our data");


    }

}
