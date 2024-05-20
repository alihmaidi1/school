using FluentValidation;
using infrastructure;

namespace Teacher.Quez.Query.GetAllQuez;

public class GetAllTeacherQuezValidation: AbstractValidator<GetAllQuezQuery>
{


    public GetAllTeacherQuezValidation(ApplicationDbContext context){




        RuleFor(x=>x.YearId)
        .NotEmpty()
        .NotNull()
        .Must(id=>context.Years.Any(x=>x.Id==id))
        .WithMessage("this id is not exists in our data");
    }


}
