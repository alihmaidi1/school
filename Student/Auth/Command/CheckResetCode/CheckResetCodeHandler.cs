using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Domain.Entities.Account;
using Dto.Admin.Auth.Dto;
using infrastructure;
using Microsoft.AspNetCore.Mvc;
using Repository.Jwt;
using Shared.CQRS;
using Shared.Enum;
using Shared.OperationResult;

namespace Student.Auth.Command.CheckResetCode;

public class CheckResetCodeHandler : OperationResult,ICommandHandler<CheckResetCodeCommand>
{

    private ApplicationDbContext _context;
    private JwtRepository _jwtRepository;

    private IMapper _mapper;
    public CheckResetCodeHandler(ApplicationDbContext context,JwtRepository jwtRepository,IMapper mapper){

        _context=context;

        _jwtRepository =jwtRepository;
        _mapper=mapper;
    }
    public async Task<JsonResult> Handle(CheckResetCodeCommand request, CancellationToken cancellationToken)
    {
        var Parent=_context.Students.Where(x=>x.Status).FirstOrDefault(x=>x.Email==request.Email&&x.ResetCode==request.Code);
        if(Parent is null) return ValidationError("Email","email or code is not exists");
        AccountSession accountSession =await _jwtRepository.GetTokensInfo(Parent.Id, Parent.Email,nameof(JwtSchema.Student),null);
        accountSession.FcmToken=request.FcmToken;
        _context.AccountSessions.Add(accountSession);
        _context.SaveChanges();
        var Result=_mapper.Map<AdminRefreshTokenDto>(accountSession);
        return Success(Result,"this is home data");

        
    }
}
