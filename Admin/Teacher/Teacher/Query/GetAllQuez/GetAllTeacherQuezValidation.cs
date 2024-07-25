using FluentValidation;
using infrastructure;

namespace Admin.Teacher.Teacher.Query.GetAllQuez;

public class GetAllTeacherQuezValidation: AbstractValidator<GetAllTeacherQuezQuery>
{


    public GetAllTeacherQuezValidation(ApplicationDbContext context){


        RuleFor(x=>x.Id)
        .NotEmpty()
        .NotNull()
        .Must(id=>context.Teachers.Any(x=>x.Id==id))
        .WithMessage("this teacher is not exists in our data");


        RuleFor(x=>x.YearId)
        .Must(id=>context.Years.Any(x=>x.Id==id))
        .When(x=>x.YearId.HasValue)
        .WithMessage("this id is not exists in our data");
    }


}
