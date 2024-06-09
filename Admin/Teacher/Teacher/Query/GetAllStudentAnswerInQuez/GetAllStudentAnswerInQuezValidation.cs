using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;
using infrastructure;
using Microsoft.EntityFrameworkCore;

namespace Admin.Teacher.Teacher.Query.GetAllStudentAnswerInQuez;

public class GetAllStudentAnswerInQuezValidation: AbstractValidator<GetAllStudentAnswerInQuezQuery>
{

    public GetAllStudentAnswerInQuezValidation(ApplicationDbContext context){

        
        

        RuleFor(x=>x.StudentId)
        .NotEmpty()
        .NotNull();

        RuleFor(x=>x.QuezId)
        .NotEmpty()
        .NotNull()
        .Must((request,id)=>context.StudentQuezs.AsNoTracking().Any(x=>x.QuezId==id&&x.StudentId==request.StudentId))
        .WithMessage("this student does not has this quez");


    }

}
