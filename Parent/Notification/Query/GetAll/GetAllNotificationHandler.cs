using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Common.CQRS;
using Domain.Dto.Notification;
using infrastructure;
using Microsoft.AspNetCore.Mvc;
using Shared.Entity.EntityOperation;
using Shared.OperationResult;
using Shared.Services.User;

namespace Parent.Notification.Query.GetAll;

public class GetAllNotificationHandler : OperationResult,IQueryHandler<GetAllNotificationQuery>
{

    private ApplicationDbContext _context;
    private ICurrentUserService _currentUserService;
    public GetAllNotificationHandler(ApplicationDbContext context,ICurrentUserService currentUserService){

        _context=context;
        _currentUserService=currentUserService;

    }
    public async Task<JsonResult> Handle(GetAllNotificationQuery request, CancellationToken cancellationToken)
    {

        var Notifications=_context
        .AccountNotifications
        .Where(x=>x.AccountId==_currentUserService.GetUserid())
        .Select(x=>new GetAllNotificationDto{
            Id=x.Id,
            Title=x.Notification.Title,
            Body=x.Notification.Body,
            Date=x.DateCreated,
        })
        .ToPagedList(request.PageNumber,request.PageSize);
        return Success(Notifications,"this is all your notification");


    }
}
