using FluentValidation;
using infrastructure;

namespace Teacher.Quez.Query.GetAllQuez;

public class GetAllTeacherQuezValidation: AbstractValidator<GetAllQuezQuery>
{


    public GetAllTeacherQuezValidation(ApplicationDbContext context){




        RuleFor(x=>x.YearId)
        .Must(id=>context.Years.Any(x=>x.Id==id))
        .When(x=>x.YearId.HasValue)        
        .WithMessage("this id is not exists in our data");
    }


}
