using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using FluentValidation;
using infrastructure;
using Org.BouncyCastle.Math.EC.Rfc7748;

namespace Admin.ClassRoom.Class.Command.FinishYear;

public class FinishYearValidation: AbstractValidator<FinishYearCommand>
{

    public FinishYearValidation(ApplicationDbContext context){

        RuleFor(x=>x.ClassId)
        .NotEmpty()
        .NotNull()
        .Must(id=>context.Classes.AsNoTracking().Any(x=>x.Id==id))
        .WithMessage("this class year is not exists")        
        .Must(id=>context.ClassYears.AsNoTracking().Any(x=>x.ClassId==id&&x.Status))
        .WithMessage("this class year is not active")
        .Must(id=>context.StudentSubjects.AsNoTracking().Where(x=>x.SubjectYear.ClassYear.ClassId==id&&x.SubjectYear.ClassYear.Status).Any())
        .WithMessage("you dont have any student in this class year to finish")
        .Must(id=>!context
            .SubjectYears
            .AsNoTracking()            
            .Where(x=>x.StudentSubjects.Any(x=>x.Mark==null))
            .Where(x=>x.ClassYear.ClassId==id)
            .Where(x=>x.ClassYear.Status)            
            .Any())
        .WithMessage("you cannot finish this year because not all mark to students are added");

    }

}
