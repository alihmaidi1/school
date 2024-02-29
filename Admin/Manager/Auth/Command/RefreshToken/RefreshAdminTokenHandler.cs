using Domain.Entities.Admin;
using Dto;
using infrutructure;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Repository.Jwt;
using Repository.Jwt.Factory;
using Shared.Enum;
using Shared.OperationResult;

namespace Admin.Auth.Command.RefreshToken;

public class RefreshAdminTokenHandler:OperationResult,
    IRequestHandler<RefreshAdminTokenCommand, JsonResult>
{
    
    private IJwtRepository jwtRepository;
    private readonly ApplicationDbContext DbContext;


    public RefreshAdminTokenHandler(ApplicationDbContext DbContext,ISchemaFactory SchemaFactory)
    {

        this.DbContext = DbContext;
        this.jwtRepository = SchemaFactory.CreateJwt(JwtSchema.Admin);


    }
    
    public async Task<JsonResult> Handle(RefreshAdminTokenCommand request, CancellationToken cancellationToken)
    {
        AdminRefreshToken? RefreshToken =  DbContext.AdminRefreshTokens
            .Include(x => x.Admin)
            .Select(x=>new AdminRefreshToken()
            {
                Id = x.Id,
                ExpireAt = x.ExpireAt,
                Admin = x.Admin,
                Token = x.Token
                
            })
            .FirstOrDefault(x => x.Token.Equals(request.RefreshToken));

        Domain.Entities.Admin.Admin Admin = RefreshToken.Admin;

        DbContext.AdminRefreshTokens.Remove(RefreshToken);
        
        var TokensData = await this.jwtRepository.GetTokensInfo(Admin.Id.Value,Admin.Email);
        
        TokenDto TokenInfo = TokenDto.ToTokenDto(TokensData.token,TokensData.ExpiredAt,TokensData.refreshToken.Token);
        return Success(TokenInfo);

    }
}