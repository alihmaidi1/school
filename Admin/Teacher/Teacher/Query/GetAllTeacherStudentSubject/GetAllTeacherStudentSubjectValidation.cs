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
        .NotEmpty()
        .NotNull()
        .Must(id=>context.Years.Any(x=>x.Id==id))
        .WithMessage("this year is not exists in our data");
   
   
        RuleFor(x=>x.TeacherId)
        .NotEmpty()
        .NotNull()
        .Must(id=>context.Teachers.Any(x=>x.Id==id))
        .WithMessage("this year is not exists in our data");
    }


}
