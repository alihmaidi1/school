using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;
using infrastructure;

namespace Admin.Teacher.Teacher.Query.GetAllQuezDetail;

public class GetAllQuezDetailValidation: AbstractValidator<GetAllQuezDetailQuery>
{

    public GetAllQuezDetailValidation(ApplicationDbContext context){

        RuleFor(x=>x.Id)
        .NotEmpty()
        .NotNull()
        .Must(id=>context.Quezs.Any(x=>x.Id==id))
        .WithMessage("this quez is not exists");


    }

}
