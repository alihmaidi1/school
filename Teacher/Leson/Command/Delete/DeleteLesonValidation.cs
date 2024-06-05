using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;
using infrastructure;
using Microsoft.EntityFrameworkCore;
using Shared.Services.User;

namespace Teacher.Leson.Command.Delete;

public class DeleteLesonValidation: AbstractValidator<DeleteLesonCommand>
{

    public DeleteLesonValidation(ApplicationDbContext context,ICurrentUserService currentUserService){

        RuleFor(x=>x.Id)
        .NotNull()
        .NotEmpty()
        .Must(id=>context.Lesons.Any(x=>x.Id==id&&x.SubjectYear.TeacherSubject.TeacherId==currentUserService.UserId))
        .WithMessage("this leson is not exists in our data");

    }

}
