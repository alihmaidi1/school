using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;
using infrastructure;

namespace Admin.Student.Student.Query.GetAllInstallment;

public class GetAllInstallmentValidation: AbstractValidator<GetAllInstallmentQuery>
{

    public GetAllInstallmentValidation(ApplicationDbContext context){

        RuleFor(x=>x.Id)
        .NotEmpty()
        .NotNull()
        .Must(id=>context.Students.Any(x=>x.Id==id))
        .WithMessage("this student is not exists in our data");

    }

}
