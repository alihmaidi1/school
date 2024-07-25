
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;
using infrastructure;

namespace Admin.ClassRoom.Student.Query.GetSubjectByYear;

public class GetStudentSubjectByYearValidation:AbstractValidator<GetStudentSubjectByYearQuery>
{


    public GetStudentSubjectByYearValidation(ApplicationDbContext context){


        RuleFor(x=>x.Id)
        .NotEmpty()
        .NotNull()
        .Must(id=>context.Students.Any(x=>x.Id==id))
        .WithMessage("this student is not exists in our data");


        RuleFor(x=>x.YearId)
        .Must(id=>context.Years.Any(x=>x.Id==id))
        .When(x=>x.YearId.HasValue)
        .WithMessage("year id is not exists in our data");


    }

}
