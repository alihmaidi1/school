using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;
using infrastructure;

namespace Admin.Teacher.Teacher.Query.GetAllTeacherStudentSubject;

public class GetAllTeacherStudentSubjectValidation: AbstractValidator<GetAllTeacherStudentSubjectQuery>
{

    public GetAllTeacherStudentSubjectValidation(ApplicationDbContext context){

        RuleFor(x=>x.YearId)
        .Must(id=>context.Years.Any(x=>x.Id==id))
        .When(x=>x.YearId.HasValue)
        .WithMessage("this year is not exists in our data");
   
   
        RuleFor(x=>x.Id)
        .NotEmpty()
        .NotNull()
        .Must(id=>context.Teachers.Any(x=>x.Id==id))
        .WithMessage("this year is not exists in our data");
    }


}
