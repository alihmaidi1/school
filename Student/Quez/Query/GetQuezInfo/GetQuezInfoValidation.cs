using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;
using infrastructure;

namespace Student.Quez.Query.GetQuezInfo;

public class GetQuezInfoValidation: AbstractValidator<GetQuezInfoQuery>
{

    public GetQuezInfoValidation(ApplicationDbContext context){

        RuleFor(x=>x.Id)
        .NotEmpty()
        .NotNull()        
        .Must(id=>context.StudentQuezs.Any(x=>x.Id==id))
        .WithMessage("this quez is not exists");
    }

}
