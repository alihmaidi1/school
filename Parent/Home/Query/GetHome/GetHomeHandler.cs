using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Common.CQRS;
using Domain.Dto.ClassRoom;
using Domain.Dto.Notification;
using Domain.Dto.Parent;
using infrastructure;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Shared.Entity.EntityOperation;
using Shared.OperationResult;

namespace Parent.Home.Query.GetHome;

public class GetHomeHandler : OperationResult,IQueryHandler<GetHomeQuery>
{

    private ApplicationDbContext _context;
    public GetHomeHandler(ApplicationDbContext context){

        _context=context;

    }


    public async Task<JsonResult> Handle(GetHomeQuery request, CancellationToken cancellationToken)
    {

        return null;

        // var Result=new GetParentHomeDto();

        // var ChildFilter=request.Childs?.Any()??false;
        // Result.Notifications=_context
        // .AccountNotifications
        // .Where(x=>ChildFilter?request.Childs!.Contains(x.AccountId):true)
        // .Select(x=>new GetAllNotificationDto{

        //     Id=x.Id,
        //     Title=x.Notification.Title,
        //     Body=x.Notification.Body,
        //     Date=x.DateCreated

        // })
        // .ToList();

        // Result.Banners=_context
        // .Banners
        // .Where(x=>x.StartAt>=DateTimeOffset.UtcNow)
        // .Where(x=>x.EndAt<=DateTimeOffset.UtcNow)
        // .Select(x=>new GetAllBannerDto{

        //     Id=x.Id,
        //     Name=x.Name,
        //     Image=x.Image,
        //     Url=x.Url            


        // })
        // .ToList();

        // return Success(Result);
    }
}
