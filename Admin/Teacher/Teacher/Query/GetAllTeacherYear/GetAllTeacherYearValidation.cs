using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;
using infrastructure;

namespace Admin.Teacher.Teacher.Query.GetAllTeacherYear;

public class GetAllTeacherYearValidation: AbstractValidator<GetAllTeacherYearQuery>
{

    public GetAllTeacherYearValidation(ApplicationDbContext context){


        RuleFor(x=>x.Id)
        .NotEmpty()
        .NotNull()
        .Must(id=>context.Teachers.Any(x=>x.Id==id))
        .WithMessage("this teacher is not exists in our data");

    }

}
