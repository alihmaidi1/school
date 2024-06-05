using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;
using infrastructure;

namespace Teacher.Quez.Query.GetQuestion;

public class GetQuezQuestionValidation: AbstractValidator<GetQuezQuestionQuery>
{

    public GetQuezQuestionValidation(ApplicationDbContext context){


        RuleFor(x=>x.QuezId)
        .NotEmpty()
        .NotNull()
        .Must(id=>context.Quezs.Any(x=>x.Id==id))
        .WithMessage("this quez is not exists in our data");

    }

}
