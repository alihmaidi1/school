using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;
using infrastructure;

namespace Admin.Teacher.Teacher.Query.GetStudentMarkInQuez;

public class GetStudentMarkInQuezValidation: AbstractValidator<GetStudentMarkInQuezQuery>
{

    public GetStudentMarkInQuezValidation(ApplicationDbContext context){

        RuleFor(x=>x.Id)
        .NotEmpty()
        .NotNull()
        .Must(id=>context.Quezs.Any(x=>x.Id==id&&x.EndAt>DateTimeOffset.UtcNow))
        .WithMessage("this quez is not exists in our data or it is not finished");

    }

}
