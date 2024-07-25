using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;
using infrastructure;
using Shared.Services.User;

namespace Teacher.Subject.Command.AddSession;

public class AddSessionValidation: AbstractValidator<AddSessionCommand>
{

    public AddSessionValidation(ApplicationDbContext context,ICurrentUserService currentUserService){


        RuleFor(x=>x.StudentIds)
        .NotEmpty()
        .NotNull();


        RuleFor(x=>x.SubjectId)
        .NotEmpty()
        .NotNull()
        .Must((request,id)=>context.SubjectYears.AsNoTracking().Any(x=>x.TeacherId==currentUserService.GetUserid()&&x.SubjectId==id&&x.ClassYear.Status))
        .WithMessage("you are not have this subject in this year")
        .Must((request,subjectid)=>{

            return context.StudentSubjects.AsNoTracking().Count(x=>request.StudentIds.Contains(x.StudentId)&&x.SubjectYear.SubjectId==subjectid&&x.SubjectYear.ClassYear.Status)==request.StudentIds.Count();
        })
        .WithMessage("some student not have this subject now");



    }

}
