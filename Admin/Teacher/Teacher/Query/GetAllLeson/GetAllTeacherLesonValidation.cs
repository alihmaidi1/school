using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;
using infrastructure;

namespace Admin.Teacher.Teacher.Query.GetAllLeson;

public class GetAllTeacherLesonValidation: AbstractValidator<GetAllTeacherLesonQuery>
{


    public GetAllTeacherLesonValidation(ApplicationDbContext context){


        RuleFor(x=>x.Id)
        .NotEmpty()
        .NotNull()
        .Must(id=>context.Teachers.Any(x=>x.Id==id))
        .WithMessage("this teacher is not exists in our data");


        RuleFor(x=>x.YearId)
        .NotEmpty()
        .NotNull()
        .Must((request,id)=>context.Years.Any(x=>x.Id==id))
        .WithMessage("this year is not exists or teacher is not learning in this year");
    }



}
