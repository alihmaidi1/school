using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;
using infrastructure;

namespace Admin.ClassRoom.Subject.Query.GetAudience;

public class GetAudienceValidation: AbstractValidator<GetAudienceQuery>
{

    public GetAudienceValidation(ApplicationDbContext context){



        RuleFor(x=>x.YearId)
        .NotEmpty()
        .NotNull();


        RuleFor(x=>x.SessionNumber)
        .NotEmpty()
        .NotNull();


        RuleFor(x=>x.SubjectId)
        .NotEmpty()
        .NotNull()
        .Must((request,id)=>
            context.
            Audiences
            .Any(x=>x.SessionNumber==request.SessionNumber&&
                    x.SubjectYear.SubjectId==id&&
                    x.SubjectYear.ClassYear.YearId==request.YearId
                )
        )
        .WithMessage("this subject does not have this session number in this year");


    }

}
