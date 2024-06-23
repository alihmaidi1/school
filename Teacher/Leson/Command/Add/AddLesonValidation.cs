using System;
using System.Collections.Generic;
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
        .Must(id=>context.SubjectYears.Any(x=>x.TeacherSubject.SubjectId==id&&x.ClassYear.Status&&x.TeacherSubject.TeacherId==currentUserService.GetUserid()))
        .WithMessage("this subject is not exists or not belongs to this teacher");
        
    }


}
