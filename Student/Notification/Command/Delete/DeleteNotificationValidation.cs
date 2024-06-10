using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;
using infrastructure;
using Shared.Services.User;

namespace Student.Notification.Command.Delete;

public class DeleteNotificationValidation: AbstractValidator<DeleteNotificationCommand>
{

    public DeleteNotificationValidation(ApplicationDbContext context,ICurrentUserService currentUserService){

        RuleFor(x=>x.Id)
        .NotEmpty()
        .NotNull()
        .Must(id=>context.AccountNotifications.Any(x=>x.Id==id&&x.AccountId==currentUserService.UserId))
        .WithMessage("this notification is not exists or not belongs to you");
    }

}
