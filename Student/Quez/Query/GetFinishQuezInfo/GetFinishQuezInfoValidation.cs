using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;
using infrastructure;

namespace Student.Quez.Query.GetFinishQuezInfo;
public class GetFinishQuezInfoValidation: AbstractValidator<GetFinishQuezInfoQuery>
{

    public GetFinishQuezInfoValidation(ApplicationDbContext context){

        RuleFor(x=>x.StudentQuezId)
        .NotEmpty()
        .NotNull()
        .Must(id=>context.StudentQuezs.Any(x=>x.Id==id&&x.Quez.EndAt<DateTimeOffset.UtcNow))
        .WithMessage("quez is not finish");

    }

}
