using AutoMapper;
using Common.CQRS;
using Domain.Dto.Manager.Admin;
using Domain.Entities.Account;
using Dto.Admin.Auth.Dto;
using infrastructure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Org.BouncyCastle.Math.EC.Rfc7748;
using Repository.Jwt;
using Shared.CQRS;
using Shared.Enum;
using Shared.Helper;
using Shared.OperationResult;

namespace Admin.Manager.Auth.Command.Login;

public class LoginAdminHandler:OperationResult,ICommandHandler<LoginAdminCommand>
{

    private readonly IJwtRepository _jwtRepository;
    private readonly ApplicationDbContext _dbContext;

    public LoginAdminHandler(ApplicationDbContext dbContext,IJwtRepository jwtRepository)
    {
        
        _dbContext = dbContext;
        _jwtRepository = jwtRepository;

    }
    
    public async Task<JsonResult> Handle(LoginAdminCommand request, CancellationToken cancellationToken)
    {
        var admin = _dbContext.Admins.IgnoreQueryFilters().Include(x=>x.Role).FirstOrDefault(x=>x.Email.Equals(request.Email));
        if (!PasswordHelper.VerifyPassword(request.Password,admin!.Password)||!admin.Status)
        {
            return ValidationError(nameof(request.Password),"password is not correct or this admin is blocked");
        }
        AccountSession accountSession =await _jwtRepository.GetTokensInfo(admin.Id, admin.Email,nameof(JwtSchema.Admin),admin.Role.Permissions);
        accountSession.FcmToken=request.FcmToken;
        _dbContext.AccountSessions.Add(accountSession);
        _dbContext.SaveChanges();
        var Response=new LoginAdminDto{

            Token=accountSession.Token,
            RefreshToken=accountSession.RefreshToken,
            ExpireAt=accountSession.ExpireAt.ToString(),
            Permissions=admin.Role.Permissions

        };
        return Success(Response,"this this your login info");
        
    }
}