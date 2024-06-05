using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities.Quez;
using FluentValidation;
using infrastructure;
using Shared.Services.User;

namespace Teacher.Quez.Command.Delete;

public class DeleteQuezValidation: AbstractValidator<DeleteQuezCommand>
{

    public DeleteQuezValidation(ApplicationDbContext context,ICurrentUserService currentUserService){

        RuleFor(x=>x.Id)
        .NotEmpty()
        .NotNull()
        .Must(id=>context.Quezs.Any(x=>(x.StartAt<DateTimeOffset.UtcNow||x.StartAt.AddSeconds(x.Questions.Sum(x=>x.Time))>DateTimeOffset.UtcNow)&&x.SubjectYear.TeacherSubject.TeacherId==currentUserService.UserId))
        .WithMessage("you can not delete this quez because it is active");
    }

}
