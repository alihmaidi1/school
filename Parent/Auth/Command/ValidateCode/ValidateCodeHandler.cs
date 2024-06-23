using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Domain.Dto.ClassRoom;
using Domain.Dto.Parent;
using Domain.Dto.Student;
using Domain.Entities.Account;
using Dto.Admin.Auth.Dto;
using infrastructure;
using Microsoft.AspNetCore.Mvc;
using Repository.Jwt;
using Shared.CQRS;
using Shared.Enum;
using Shared.OperationResult;

namespace Parent.Auth.Command.ValidateCode;

public class ValidateCodeHandler : OperationResult,ICommandHandler<ValidateCodeCommand>
{

    private ApplicationDbContext _context;


    private IMapper _mapper;
    private IJwtRepository _jwtRepository;
    public ValidateCodeHandler(ApplicationDbContext context,IJwtRepository jwtRepository,IMapper mapper){

        _context=context;
        _mapper=mapper;
        _jwtRepository=jwtRepository;
    }
    public async Task<JsonResult> Handle(ValidateCodeCommand request, CancellationToken cancellationToken)
    {

        var Parent=_context.Parents.First(x=>x.Email==request.Email);
        if(request.Code!=Parent.Code) return ValidationError("Code","Your Code Is Not Correct");        
        AccountSession accountSession =await _jwtRepository.GetTokensInfo(Parent.Id, Parent.Email,nameof(JwtSchema.Parent),null);
        accountSession.FcmToken=request.FcmToken;
        _context.AccountSessions.Add(accountSession);
        _context.SaveChanges();

        var Result=new GetParentHomeDto();

        Result.TokenInfo=_mapper.Map<AdminRefreshTokenDto>(accountSession);

        Result.Banners=_context
        .Banners
        .AsNoTracking()
        .Where(x=>x.StartAt>=DateTimeOffset.UtcNow)
        .Where(x=>x.EndAt<=DateTimeOffset.UtcNow)
        .Select(x=>new GetAllBannerDto{

            Id=x.Id,
            Name=x.Name,
            Image=x.Image,
            Url=x.Url            


        })
        .ToList();

        Result.NotificationCount=_context.AccountNotifications.Where(x=>x.AccountId==Parent.Id).Count();

        
        Result.Students=_context
        .Students
        .AsNoTracking()
        .Where(x=>x.ParentId==Parent.Id)
        .Select(x=>new GetAllStudentDto{

            Id=x.Id,
            Name=x.Name,
            Image=x.Image,
            Hash=x.Hash

        })
        .ToList();

        Result.Notifications=
        _context
        .AccountNotifications
        .Where(x=>Result.Students.Select(x=>x.Id).Contains(x.AccountId))
        
        .Select(x=>new GetAllStudentNotificationDto{

            Id=x.Id,
            Body=x.Notification.Body,
            Title=x.Notification.Title,
            StudentName=x.Account.Name
                    
        })
        .ToList();

        return Success(Result,"this is home data");




        
    }
}
