using Domain.Entities.Admin;
using Dto;
using Dto.Admin.Auth;
using infrutructure;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Repository.Jwt;
using Repository.Jwt.Factory;
using Repository.Manager.Admin;
using Shared.Enum;
using Shared.OperationResult;

namespace Admin.Auth.Command.Login;

public class LoginAdminHandler:OperationResult,
    IRequestHandler<LoginAdminCommand, JsonResult>
{
    
    
    private IJwtRepository jwtRepository;
    private IAdminRepository AdminRepository;
    private readonly ApplicationDbContext DbContext;

    public LoginAdminHandler(ApplicationDbContext DbContext,IAdminRepository AdminRepository,ISchemaFactory SchemaFactory)
    {
        
        this.DbContext = DbContext;
        this.jwtRepository = SchemaFactory.CreateJwt(JwtSchema.Admin);
        this.AdminRepository = AdminRepository;

    }
    
    public async Task<JsonResult> Handle(LoginAdminCommand request, CancellationToken cancellationToken)
    {
        Domain.Entities.Admin.Admin admin = this.AdminRepository.GetByEmail(request.Email);
        
        if (admin.Password.Equals(request.Password))
        {
            var tokens = await jwtRepository.GetTokensInfo(admin.Id.Value,admin.Email);
            AdminRefreshToken adminRefreshToken =AdminRefreshTokenDto.ToAdminRefreshToken(tokens.refreshToken.Token, tokens.refreshToken.ExpireAt);
            admin.RefreshTokens.Add(adminRefreshToken);
            DbContext.SaveChanges();
            TokenDto TokenInfo = TokenDto.ToTokenDto(tokens.token, tokens.ExpiredAt, tokens.refreshToken.Token);
            return Success(TokenInfo,"You are login successfully");
        }

        return Fail("password is not correct");

    }
}