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


                
        return Success(_mapper.Map<AdminRefreshTokenDto>(accountSession),"this this your login info");
        

        
    }
}
