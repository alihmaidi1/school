using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Dto.Admin.Auth.Dto;
using infrastructure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Repository.Jwt;
using Shared.CQRS;
using Shared.OperationResult;

namespace Teacher.Auth.RefreshToken;

public class RefreshTokenTeacherHandler : OperationResult, ICommandHandler<RefreshTokenTeacherCommand>
{


    private readonly ApplicationDbContext _dbContext;
    private readonly IMapper _mapper;

    private readonly IJwtRepository _jwtRepository;
    public RefreshTokenTeacherHandler(IJwtRepository jwtRepository,ApplicationDbContext context,IMapper mapper){



        _dbContext=context;

        _mapper=mapper;

        _jwtRepository=jwtRepository;
    }
    public async Task<JsonResult> Handle(RefreshTokenTeacherCommand request, CancellationToken cancellationToken)
    {
          var userSession = _dbContext.AccountSessions.FirstOrDefault(x=>x.RefreshToken==request.RefreshToken);
        if (userSession is null)
        {
            return ValidationError(nameof(request.RefreshToken),"refresh token is not correct");
        }
        var teacher = _dbContext.Teachers.IgnoreQueryFilters().First(x => x.Id == userSession.AccountId);
        var tokensInfo =await _jwtRepository.GetTokensInfo(userSession.AccountId,teacher.Email,null);
        userSession.RefreshToken = tokensInfo.RefreshToken;
        userSession.Token = tokensInfo.Token;
        userSession.ExpireAt = userSession.ExpireAt;
        await _dbContext.SaveChangesAsync(cancellationToken);
        return Success(_mapper.Map<AdminRefreshTokenDto>(userSession),"this this your login info");
      
    }
}
