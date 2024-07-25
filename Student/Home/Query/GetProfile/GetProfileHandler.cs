using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Common.CQRS;
using Domain.Dto;
using infrastructure;
using Microsoft.AspNetCore.Mvc;
using Shared.OperationResult;
using Shared.Services.User;

namespace Student.Home.Query.GetProfile;

public class GetProfileHandler : OperationResult,IQueryHandler<GetProfileQuery>
{

    private ApplicationDbContext _context;

    private ICurrentUserService _currentUserService;

    public GetProfileHandler( ApplicationDbContext context,ICurrentUserService currentUserService){


        _context=context;
        _currentUserService=currentUserService;

    }
    public async Task<JsonResult> Handle(GetProfileQuery request, CancellationToken cancellationToken)
    {
        var Parent=_context.Students.First(x=>x.Id==_currentUserService.GetUserid());


        var Profile=new GetProfileDto();
        Profile.Email=Parent.Email;
        Profile.Name=Parent.Name;
        Profile.Image=Parent.Image;
        return Success(Profile);


        
        
    }
}
