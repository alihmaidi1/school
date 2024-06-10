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
        return Success(_mapper.Map<AdminRefreshTokenDto>(accountSession),"this this your login info");
        

        
    }
}
