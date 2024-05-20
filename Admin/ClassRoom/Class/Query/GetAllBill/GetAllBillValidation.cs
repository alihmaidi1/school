using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;
using infrastructure;

namespace Admin.ClassRoom.Class.Query.GetAllBill;

public class GetAllBillValidation: AbstractValidator<GetAllBillQuery>
{

    public GetAllBillValidation(ApplicationDbContext context){

        RuleFor(x=>x.ClassId)
        .NotEmpty()
        .NotNull()
        .Must(id=>context.Classes.Any(x=>x.Id==id))
        .WithMessage("this class is not exists in our data");


        RuleFor(x=>x.YearId)
        .NotEmpty()
        .NotNull()
        .Must(id=>context.Years.Any(x=>x.Id==id))
        .WithMessage("this year is not exists in our data");

    }

}
