using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities.Account;
using infrastructure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Infrastructure;
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

        // var Notification=new Domain.Entities.Account.Notification{
        //     Title=request.Title,
        //     Body=request.Body,
        // };

        // List<Guid> AccountIds=new List<Guid>();

        // if(request.NotificationType==Domain.Enum.NotificationType.Public){

        //     AccountIds=_context.Accounts.Select(x=>x.Id).ToList();
        // }else if(request.NotificationType==Domain.Enum.NotificationType.Class){

        //     AccountIds=_context
        //     .SubjectYears
        //     .Where(x=>x.Year.Date.Year==DateTime.Now.Year)            
        //     .Where(x=>request.Ids.Contains(x.Subject.ClassId))            
        //     .SelectMany(x=>x.StudentSubjects)
        //     .Select(x=>x.StudentId)
        //     .Distinct()
        //     .ToList();
            
        // }else {

        //     AccountIds=request.Ids!;

        // }
        // var AccountNotifications=AccountIds.Select(x=>new AccountNotification{

        //     AccountId=x

        // }).ToList();
        // Notification.AccountNotifications=AccountNotifications;
        // _context.Notifications.Add(Notification);
        // await _context.SaveChangesAsync(cancellationToken);
        // return Success("notification was created successfully");
        
        return null;
    }
}
