using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Domain.Dto.ClassRoom;
using Domain.Dto.Student;
using Domain.Entities.Account;
using Dto.Admin.Auth.Dto;
using infrastructure;
using Microsoft.AspNetCore.Mvc;
using Repository.Jwt;
using Shared.CQRS;
using Shared.Enum;
using Shared.OperationResult;
using Shared.Services.User;

namespace Student.Auth.Command.ValidateCode;

public class ValidateCodeHandler : OperationResult,ICommandHandler<ValidateCodeCommand>
{

    private ApplicationDbContext _context;
    private ICurrentUserService _currentUserService;

    private IMapper _mapper;
    private IJwtRepository _jwtRepository;
    public ValidateCodeHandler(ICurrentUserService currentUserService,ApplicationDbContext context,IJwtRepository jwtRepository,IMapper mapper){

        _context=context;
        _mapper=mapper;
        _jwtRepository=jwtRepository;
        _currentUserService=currentUserService;
    }
    public async Task<JsonResult> Handle(ValidateCodeCommand request, CancellationToken cancellationToken)
    {

        var Student=_context.Students.First(x=>x.Email==request.Email);
        if(request.Code!=Student.Code) return ValidationError("Code","Your Code Is Not Correct");
        
        AccountSession accountSession =await _jwtRepository.GetTokensInfo(Student.Id, Student.Email,nameof(JwtSchema.Student),null);
        accountSession.FcmToken=request.FcmToken;
        _context.AccountSessions.Add(accountSession);
        _context.SaveChanges();


        var Home=new GetStudentHomeDto();
        Home.Banners=_context
        .Banners
        .AsNoTracking()
        .Where(x=>x.StartAt<=DateTimeOffset.UtcNow)
        .Where(x=>x.EndAt>=DateTimeOffset.UtcNow)
        .Select(x=>new GetAllBannerDto{

            Id=x.Id,
            Image=x.Image,
            Url=x.Url,
            StartAt=x.StartAt,
            EndAt=x.EndAt,
            Name=x.Name


        })
        .ToList();

        Home.Subjects=_context
        .StudentSubjects
        .AsNoTracking()
        .Where(x=>x.StudentId==Student.Id)
        .Where(x=>x.SubjectYear.ClassYear.Status)
        .Select(x=>new GetStudentHomeDto.Subject{


            Id=x.SubjectYear.Id,
            Name=x.SubjectYear.TeacherSubject.Subject.Name


        })
        .ToList();
        Home.NotificationCount=_context.AccountNotifications.Where(x=>x.AccountId==Student.Id&&!x.IsRead).Count();
        Home.TokenInfo=_mapper.Map<AdminRefreshTokenDto>(accountSession);
        return Success(Home,"this this your login info");
        

        
    }
}
