using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Event;

using MediatR;
using Shared.Services.Email;

namespace Common.Event;

public class SendEmailEventHandler : INotificationHandler<SendEmailEvent>
{


    private readonly IMailService _mailService;

    public SendEmailEventHandler(IMailService mailService){

        _mailService=mailService;

    }
    public Task Handle(SendEmailEvent notification, CancellationToken cancellationToken)
    {
          
        _mailService.SendMail(notification.Email,notification.Subject,notification.Message);
        return Task.CompletedTask;

    }
}
