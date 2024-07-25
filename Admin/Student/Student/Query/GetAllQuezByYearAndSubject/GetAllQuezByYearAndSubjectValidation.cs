using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;
using infrastructure;

namespace Admin.Student.Student.Query.GetAllQuezByYearAndSubject;

public class GetAllQuezByYearAndSubjectValidation: AbstractValidator<GetAllQuezByYearAndSubjectQuery>
{

    public GetAllQuezByYearAndSubjectValidation(ApplicationDbContext context){


        RuleFor(x=>x.Id)
        .NotEmpty()
        .NotNull()
        .Must(id=>context.Students.Any(x=>x.Id==id))
        .WithMessage("this student is not exists in our data");



        RuleFor(x=>x.YearId)
        .NotEmpty()
        .NotNull()
        .Must(id=>context.Years.Any(x=>x.Id==id))
        .When(x=>x.YearId.HasValue)
        .WithMessage("this year is not exists in our data");



    }

}
