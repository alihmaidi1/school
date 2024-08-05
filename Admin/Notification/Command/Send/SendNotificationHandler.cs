using System.Data.Entity;
using Domain.Entities.Account;
using infrastructure;
using Microsoft.AspNetCore.Mvc;
using Shared.CQRS;
using Shared.OperationResult;
using Shared.Services.User;

namespace Admin.Notification.Command.Send;

public class SendNotificationHandler : OperationResult ,ICommandHandler<SendNotificationCommand>
{

    private ApplicationDbContext _context;
    private ICurrentUserService _currentUserService;
    public SendNotificationHandler(ApplicationDbContext context,ICurrentUserService currentUserService){

        _currentUserService=currentUserService;
        _context=context;

    }
    public async Task<JsonResult> Handle(SendNotificationCommand request, CancellationToken cancellationToken)
    {

        var Notification=new Domain.Entities.Account.Notification{
            Title=request.Title,
            Body=request.Body,
        };
        
        var AccountIds=request.Ids;                
        var fcmTokens=_context
        .Accounts
        .AsNoTracking()
        .Where(x=>AccountIds.Contains(x.Id))
        .SelectMany(x=>x.AccountSessions)
        .Select(x=>x.FcmToken)
        .ToList();


        var AccountNotifications=request.Ids.Select(x=>new AccountNotification{

            AccountId=x

        }).ToList();
        Notification.AccountNotifications=AccountNotifications;
        _context.Notifications.Add(Notification);
        await _context.SaveChangesAsync(cancellationToken);
        return Success("notification was created successfully");        
    }
}
