using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;
using infrastructure;
using Microsoft.EntityFrameworkCore;
using Shared.Services.User;

namespace Teacher.Leson.Command.Delete;

public class DeleteLesonValidation: AbstractValidator<deleteLesonCommand>
{

    public DeleteLesonValidation(ApplicationDbContext context,ICurrentUserService currentUserService){

        RuleFor(x=>x.Id)
        .NotNull()
        .NotEmpty()
        .Must(id=>context.Lesons.Include(x=>x.SubjectYear).Any(x=>x.Id==id&&x.SubjectYear.TeacherId==currentUserService.UserId))
        .WithMessage("this leson is not exists in our data");

    }

}
