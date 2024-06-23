using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;
using infrastructure;
using Org.BouncyCastle.Ocsp;
using Shared.Services.User;

namespace Parent.Notification.Command.Delete;

public class DeleteNotificationValidation: AbstractValidator<DeleteNotificationCommand>
{

    public DeleteNotificationValidation(ApplicationDbContext context,ICurrentUserService currentUserService){


        RuleFor(x=>x.Id)
        .NotEmpty()
        .NotNull()
        .Must(id=>context.AccountNotifications.Any(x=>x.Id==id&&x.AccountId==currentUserService.GetUserid()))
        .WithMessage("this notification is not exists in our data or it not belongs to you");

    }

}
