using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Common.CQRS;
using Domain.Dto.ClassRoom;
using infrastructure;
using Microsoft.AspNetCore.Mvc;
using Shared.Entity.EntityOperation;
using Shared.OperationResult;

namespace Admin.ClassRoom.Banner.Query.GetAll;
public class GetAllBannerHandler : OperationResult,IQueryHandler<GetAllBannerQuery>
{

    private ApplicationDbContext _context;
    public GetAllBannerHandler(ApplicationDbContext context){

        _context=context;
    }
    public async Task<JsonResult> Handle(GetAllBannerQuery request, CancellationToken cancellationToken)
    {

        var Banners=_context
        .Banners
        .Select(x=>new GetAllBannerDto{

            Id=x.Id,
            Name=x.Name,
            StartAt=x.StartAt,
            EndAt=x.EndAt,
            Image=x.Image,
            Url=x.Url
        })
        .ToPagedList(request.PageNumber,request.PageSize);
        return Success(Banners,"this is all banners");
    }
}
