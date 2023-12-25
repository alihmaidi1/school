using Domain.Base.Entity;
using Domain.Entities.Admin;
using Domain.Enum;
using Dto;
using Dto.Admin.Auth;
using infrutructure;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Model.Admin.Auth.Command;
using Repository.Jwt;
using Repository.Jwt.Factory;
using Repository.Manager.Admin;
using Shared.Enum;
using Shared.OperationResult;

namespace Admin.Auth.Command.Handler;

public class AuthCommandHandler:OperationResult,
                                IRequestHandler<LoginAdminCommand, JsonResult>,
                                IRequestHandler<LogoutAdminCommand, JsonResult>,
                                
                                IRequestHandler<RefreshAdminTokenCommand, JsonResult>


{

    private IJwtRepository jwtRepository;
    private IAdminRepository AdminRepository;
    
    private readonly IHttpContextAccessor _httpContextAccessor;
    
    private readonly ApplicationDbContext DbContext;
    public AuthCommandHandler(IHttpContextAccessor _httpContextAccessor,ApplicationDbContext DbContext,IAdminRepository AdminRepository,ISchemaFactory SchemaFactory)
    {

        this._httpContextAccessor = _httpContextAccessor;
        this.DbContext = DbContext;
        this.jwtRepository = SchemaFactory.CreateJwt(JwtSchema.Admin);
        this.AdminRepository = AdminRepository;

    }
    
    public async Task<JsonResult> Handle(LoginAdminCommand request, CancellationToken cancellationToken)
    {
        Domain.Entities.Admin.Admin admin = this.AdminRepository.GetByEmail(request.Email);
        
        if (admin.Password.Equals(request.Password))
        {
            var tokens = await jwtRepository.GetTokensInfo(admin.Id,admin.Email);
            AdminRefreshToken adminRefreshToken =AdminRefreshTokenDto.ToAdminRefreshToken(tokens.refreshToken.Token, tokens.refreshToken.ExpireAt);
            admin.RefreshTokens.Add(adminRefreshToken);
            DbContext.SaveChanges();

            TokenDto TokenInfo = TokenDto.ToTokenDto(tokens.token, tokens.ExpiredAt, tokens.refreshToken.Token);

            return Success(TokenInfo,"You are login successfully");
        }

        return Fail("password is not correct");
        
    }

    public async Task<JsonResult> Handle(LogoutAdminCommand request, CancellationToken cancellationToken)
    {
     
        string Token = _httpContextAccessor.HttpContext.Request.Headers.Authorization.ToString().Split(" ")[1];
        bool status = AdminRepository.Logout(Token);
        return Success(status, "You Are Logout Successfully");
        
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

        
        var TokensData = await this.jwtRepository.GetTokensInfo(Admin.Id,Admin.Email);
        
        TokenDto TokenInfo = TokenDto.ToTokenDto(TokensData.token,TokensData.ExpiredAt,TokensData.refreshToken.Token);
        return Success(TokenInfo);
        
        
    }
}