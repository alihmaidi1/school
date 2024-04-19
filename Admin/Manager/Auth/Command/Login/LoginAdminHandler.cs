using AutoMapper;
using Common.CQRS;
using Domain.Entities.Account;
using Dto.Admin.Auth.Dto;
using infrastructure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Repository.Jwt;
using Shared.CQRS;
using Shared.Helper;
using Shared.OperationResult;

namespace Admin.Manager.Auth.Command.Login;

public class LoginAdminHandler:OperationResult,ICommandHandler<LoginAdminCommand>
{

    private readonly IJwtRepository _jwtRepository;
    private readonly ApplicationDbContext _dbContext;

    private readonly IMapper _mapper;
    public LoginAdminHandler(IMapper mapper,ApplicationDbContext dbContext,IJwtRepository jwtRepository)
    {
        
        _dbContext = dbContext;
        _mapper = mapper;
        _jwtRepository = jwtRepository;

    }
    
    public async Task<JsonResult> Handle(LoginAdminCommand request, CancellationToken cancellationToken)
    {
        var admin = _dbContext.Admins.IgnoreQueryFilters().Include(x=>x.Role).First(x=>x.Email.Equals(request.Email));
        if (!PasswordHelper.VerifyPassword(request.Password,admin!.Password))
        {
            return ValidationError(nameof(request.Password),"password is not correct");
        }
        AccountSession accountSession =await _jwtRepository.GetTokensInfo(admin.Id, admin.Email,admin.Role.Permissions);
        _dbContext.AccountSessions.Add(accountSession);
        _dbContext.SaveChanges();
        return Success(_mapper.Map<AdminRefreshTokenDto>(accountSession),"this this your login info");
        
    }
}