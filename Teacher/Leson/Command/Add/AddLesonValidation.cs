using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;
using infrastructure;
using Shared.Rule;
using Shared.Services.User;

namespace Teacher.Leson.Command.Add;

public class AddLesonValidation: AbstractValidator<AddLesonCommand>
{

    public AddLesonValidation(ApplicationDbContext context,ICurrentUserService currentUserService){


        RuleFor(x=>x.Name)
        .NotEmpty()
        .NotNull();


        RuleFor(x=>x.File)
        .NotEmpty()
        .NotNull()
        .Must(file=>FileRule.IsPDF(file))
        .WithMessage("file should be pdf");
    
    
        RuleFor(x=>x.SubjectId)
        .NotNull()
        .NotEmpty()
        .Must(id=>{

            if(currentUserService.IsAdmin()){

                return context.SubjectYears.AsNoTracking().Any(x=>x.ClassYear.Status&&x.SubjectId==id);
            }
            return context.SubjectYears.AsNoTracking().Any(x=>x.ClassYear.Status&&x.SubjectId==id&&x.TeacherId==currentUserService.GetUserid());

        })
        .WithMessage("this subject is not exists or not belongs to this teacher");
        
    }


}
