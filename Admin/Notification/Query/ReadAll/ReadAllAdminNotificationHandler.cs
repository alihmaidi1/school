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

namespace Admin.Notification.Query.ReadAll;

public class ReadAllAdminNotificationHandler : OperationResult, ICommandHandler<ReadAllAdminNotificationCommand>
{

    private ApplicationDbContext _context;
    private ICurrentUserService _currentUserService;
    public ReadAllAdminNotificationHandler(ApplicationDbContext context,ICurrentUserService currentUserService){

        _currentUserService=currentUserService;
        _context=context;

    }

    public async Task<JsonResult> Handle(ReadAllAdminNotificationCommand request, CancellationToken cancellationToken)
    {
        var Notifications=_context
        .Notifications
        .AsNoTracking()
        .Select(x=>new GetAllNotificationDto{

            Id=x.Id,
            Title=x.Title,
            Body=x.Body,
            Date=x.DateCreated

        })
        .ToPagedList(request.PageNumber,request.PageSize);

        await _context
        .Admins
        .AsNoTracking()
        .Where(x=>x.Id==_currentUserService.GetUserid())
        .SelectMany(x=>x.AccountNotifications)
        .ExecuteUpdateAsync(setter=>setter.SetProperty(x=>x.IsRead,true),cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);
        return Success(Notifications,"this is all your notifications");
    }
}
