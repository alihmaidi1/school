using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Dto.Notification;
using infrastructure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Shared.CQRS;
using Shared.Entity.EntityOperation;
using Shared.OperationResult;
using Shared.Services.User;

namespace Teacher.Notification.Query.GetAll;

public class ReadAllTeacherNotificationHandler : OperationResult ,ICommandHandler<ReadAllTeacherNotificationCommand>
{

    private ApplicationDbContext _context;

    private ICurrentUserService _currentUserService;
    public ReadAllTeacherNotificationHandler(ApplicationDbContext context,ICurrentUserService currentUserService){

        _context=context;
        _currentUserService=currentUserService;
    }
    public async Task<JsonResult> Handle(ReadAllTeacherNotificationCommand request, CancellationToken cancellationToken)
    {
         var Notifications=_context
        .Teachers
        .AsNoTracking()
        .Where(x=>x.Id==_currentUserService.GetUserid())
        .SelectMany(x=>x.AccountNotifications)        
        .Select(x=>new GetAllNotificationDto{

            Id=x.NotificationId,
            Title=x.Notification.Title,
            Body=x.Notification.Body

        })
        .ToPagedList(request.PageNumber,request.PageSize);
        await _context
        .Teachers
        .AsNoTracking()
        .Where(x=>x.Id==_currentUserService.GetUserid())
        .SelectMany(x=>x.AccountNotifications)
        .ExecuteUpdateAsync(setter=>setter.SetProperty(x=>x.IsRead,true),cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);
        return Success(Notifications,"this is all your notifications");
    }
}
