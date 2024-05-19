using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Domain.Entities.Account;
using Dto.Admin.Auth.Dto;
using infrastructure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Repository.Jwt;
using Shared.CQRS;
using Shared.Enum;
using Shared.Helper;
using Shared.OperationResult;

namespace Teacher.Auth.Login;

public class LoginteacherHandler : OperationResult, ICommandHandler<LoginTeacherCommand>
{

    private readonly ApplicationDbContext _dbContext;
    private readonly IJwtRepository _jwtRepository;
    private readonly IMapper _mapper;
    public LoginteacherHandler(IMapper mapper,ApplicationDbContext context,IJwtRepository jwtRepository){

        _dbContext=context;
        _jwtRepository=jwtRepository;
        _mapper=mapper;

    }

    public async Task<JsonResult> Handle(LoginTeacherCommand request, CancellationToken cancellationToken)
    {

        var teacher = _dbContext.Teachers.IgnoreQueryFilters().First(x=>x.Email.Equals(request.Email));
        if (!PasswordHelper.VerifyPassword(request.Password,teacher!.Password))
        {
            return ValidationError(nameof(request.Password),"password is not correct");
        }
        AccountSession accountSession =await _jwtRepository.GetTokensInfo(teacher.Id, teacher.Email,nameof(JwtSchema.Admin),null);
        _dbContext.AccountSessions.Add(accountSession);
        _dbContext.SaveChanges();
        return Success(_mapper.Map<AdminRefreshTokenDto>(accountSession),"this this your login info");
        

    }
}
