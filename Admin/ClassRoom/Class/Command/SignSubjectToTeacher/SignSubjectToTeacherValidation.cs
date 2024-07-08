using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;
using infrastructure;

namespace Admin.ClassRoom.Class.Command.SignSubjectToTeacher;
public class SignSubjectToTeacherValidation: AbstractValidator<SignSubjectToTeacherCommand>
{

    public SignSubjectToTeacherValidation(ApplicationDbContext context){




        RuleFor(x=>x.SubjectId)
        .NotEmpty()
        .NotNull()
        .Must(id=>context.SubjectYears.Include(x=>x.Teacher).Any(x=>x.Id==id&&x.Teacher==null))
        .WithMessage("this subject already has teacher");





        RuleFor(x=>x.TeacherId)
        .NotEmpty()
        .NotNull()
        .Must((request,teacherid)=>{

            var SubjectId=context.SubjectYears.Select(x=>x.Id).First(x=>x==request.SubjectId);
            return context.TeacherSubjects.Any(x=>x.TeacherId==teacherid&&x.SubjectId==SubjectId);

        })
        .WithMessage("this teacher does not have this subject");





    }

}