using AutoMapper;
using Dto.Admin.Auth.Dto;
using infrastructure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Repository.Jwt;
using Shared.CQRS;
using Shared.OperationResult;

namespace Admin.Manager.Auth.Command.RefreshToken;

public class RefreshAdminTokenHandler:OperationResult,ICommandHandler<RefreshAdminTokenCommand>
{
    
    private readonly IJwtRepository _jwtRepository;
    private readonly ApplicationDbContext _dbContext;
    private readonly IMapper _mapper;


    public RefreshAdminTokenHandler(IMapper mapper,ApplicationDbContext dbContext, IJwtRepository jwtRepository)
    {
        _dbContext = dbContext;
        _mapper = mapper;
        _jwtRepository = jwtRepository;
    }
    
    public async Task<JsonResult> Handle(RefreshAdminTokenCommand request, CancellationToken cancellationToken)
    {
        var userSession = _dbContext.AccountSessions.FirstOrDefault(x=>x.RefreshToken==request.RefreshToken);
        if (userSession is null)
        {
            return ValidationError(nameof(request.RefreshToken),"refresh token is not correct");
        }
        var admin = _dbContext.Admins.IgnoreQueryFilters().Include(admin => admin.Role).First(x => x.Id == userSession.AccountId);
        var tokensInfo =await _jwtRepository.GetTokensInfo(userSession.AccountId, admin.Email,admin.Role.Permissions);
        userSession.RefreshToken = tokensInfo.RefreshToken;
        userSession.Token = tokensInfo.Token;
        userSession.ExpireAt = userSession.ExpireAt;
        await _dbContext.SaveChangesAsync(cancellationToken);
        return Success(_mapper.Map<AdminRefreshTokenDto>(userSession),"this this your login info");
        
    }
}