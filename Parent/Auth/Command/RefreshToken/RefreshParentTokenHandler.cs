using AutoMapper;
using Dto.Admin.Auth.Dto;
using infrastructure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Repository.Jwt;
using Shared.CQRS;
using Shared.Enum;
using Shared.OperationResult;

namespace Parent.Auth.Command.RefreshToken;

public class RefreshParentTokenHandler : OperationResult,ICommandHandler<RefreshParentTokenCommand>
{

    private ApplicationDbContext _context;

    private IJwtRepository _jwtRepository;


    private IMapper _mapper;
    public RefreshParentTokenHandler(IMapper mapper,ApplicationDbContext context,IJwtRepository jwtRepository){

        _jwtRepository=jwtRepository;
        _context=context;
        _mapper=mapper;
    }
    public async Task<JsonResult> Handle(RefreshParentTokenCommand request, CancellationToken cancellationToken)
    {
        var userSession = _context.AccountSessions.FirstOrDefault(x=>x.RefreshToken==request.RefreshToken);
        if (userSession is null)
        {
            return ValidationError(nameof(request.RefreshToken),"refresh token is not correct");
        }
        var teacher = _context.Parents.IgnoreQueryFilters().Where(x=>x.DateDeleted==null).First(x => x.Id == userSession.AccountId);
        var tokensInfo =await _jwtRepository.GetTokensInfo(userSession.AccountId,teacher.Email,nameof(JwtSchema.Parent),null);
        userSession.RefreshToken = tokensInfo.RefreshToken;
        userSession.Token = tokensInfo.Token;
        userSession.ExpireAt = userSession.ExpireAt;
        await _context.SaveChangesAsync(cancellationToken);
        return Success(_mapper.Map<AdminRefreshTokenDto>(userSession),"this this your login info");

    }
}
