using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using Common.CQRS;
using Domain.Dto.ClassRoom;
using Domain.Dto.Notification;
using Domain.Dto.Parent;
using Domain.Dto.Student;
using infrastructure;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Shared.Entity.EntityOperation;
using Shared.OperationResult;
using Shared.Services.User;

namespace Parent.Home.Query.GetHome;

public class GetHomeHandler : OperationResult,IQueryHandler<GetHomeQuery>
{

    private ApplicationDbContext _context;
    private ICurrentUserService _currentUserService;
    public GetHomeHandler(ApplicationDbContext context,ICurrentUserService currentUserService){

        _context=context;

        _currentUserService=currentUserService;
    }


    public async Task<JsonResult> Handle(GetHomeQuery request, CancellationToken cancellationToken)
    {


        var Result=new GetParentHomeDto();

        var parent=_context.Parents.First(x=>x.Id==_currentUserService.GetUserid());
        Result.Name=parent.Name;
        Result.Image=parent.Image;

        Result.Students=_context
        .Students
        .AsNoTracking()
        .Where(x=>x.ParentId==_currentUserService.GetUserid())
        .Select(x=>new GetAllStudentDto{

            Id=x.Id,
            Name=x.Name,
            Image=x.Image,
            Hash=x.Hash

        })
        .ToList();


        Result.Notifications=_context
        .AccountNotifications
        .Where(x=>Result.Students.Select(x=>x.Id).Contains(x.AccountId))        
        .Select(x=>new GetAllStudentNotificationDto{

            Id=x.Id,
            Body=x.Notification.Body,
            Title=x.Notification.Title,
            StudentName=x.Account.Name
                    
        })
        .ToList();


        
        Result.Banners=_context
        .Banners
        .Where(x=>x.StartAt>=DateTimeOffset.UtcNow)
        .Where(x=>x.EndAt<=DateTimeOffset.UtcNow)
        .Select(x=>new GetAllBannerDto{

            Id=x.Id,
            Name=x.Name,
            Image=x.Image,
            Url=x.Url            


        })
        .ToList();

        Result.NotificationCount=_context.AccountNotifications.Where(x=>x.AccountId==_currentUserService.GetUserid()&&!x.IsRead).Count();



        return Success(Result);
    }
}
