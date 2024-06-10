using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;
using infrastructure;
using Shared.Services.User;

namespace Teacher.Student.Command.AddMark;

public class AddMarkValidation: AbstractValidator<AddMarkCommand>
{

    public AddMarkValidation(ApplicationDbContext context,ICurrentUserService currentUserService){


        
        RuleFor(x=>x.StudentId)
        .NotEmpty()
        .NotNull();

        RuleFor(x=>x.SubjectId)
        .NotEmpty()
        .NotNull()
        .Must((request,id)=>context
            .StudentSubjects
            .Any(x=>x.SubjectYear.TeacherSubject.SubjectId==id&&
                    x.SubjectYear.ClassYear.Status&&
                    x.StudentId==request.StudentId&&
                    x.SubjectYear.TeacherSubject.TeacherId==currentUserService.UserId)
            )
            .WithMessage("this student does not has this subject or this subject you are not learn it");


        RuleFor(x=>x.Mark)
        .NotEmpty()
        .NotNull()
        .GreaterThan(0)
        .LessThan(100);

    }

}
