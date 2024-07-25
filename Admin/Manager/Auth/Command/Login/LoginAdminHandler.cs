using Domain.Dto.Manager.Admin;
using Domain.Entities.Account;
using infrastructure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Repository.Jwt;
using Shared.CQRS;
using Shared.Enum;
using Shared.Helper;
using Shared.OperationResult;

namespace Admin.Manager.Auth.Command.Login;

public class LoginAdminHandler:OperationResult,ICommandHandler<LoginAdminCommand>
{

    private readonly Repository.Jwt.IJwtRepository _jwtRepository;
    private readonly ApplicationDbContext _dbContext;

    public LoginAdminHandler(ApplicationDbContext dbContext,Repository.Jwt.IJwtRepository jwtRepository)
    {
        
        _dbContext = dbContext;
        _jwtRepository = jwtRepository;

    }
    
    public async Task<JsonResult> Handle(LoginAdminCommand request, CancellationToken cancellationToken)
    {

        

        var admin = _dbContext
        .Admins
        .IgnoreQueryFilters()
        .Where(x=>x.Status)
        .Where(x=>x.DateDeleted==null)
        .Include(x=>x.Role)
        .FirstOrDefault(x=>x.Email.Equals(request.Email));
        var Response=new LoginAdminDto();
        if(admin is not null){

            if (!PasswordHelper.VerifyPassword(request.Password,admin!.Password)||!admin.Status)
            {
                return ValidationError(nameof(request.Password),"password is not correct or this admin is blocked");
            }

            AccountSession accountSession =await _jwtRepository.GetTokensInfo(admin.Id, admin.Email,nameof(JwtSchema.Admin),admin.Role.Permissions);
            accountSession.FcmToken=request.FcmToken;
            _dbContext.AccountSessions.Add(accountSession);
            _dbContext.SaveChanges();
            Response=new LoginAdminDto{
                Token=accountSession.Token,
                RefreshToken=accountSession.RefreshToken,
                IsAdmin=true,
                Id=admin.Id,
                ExpireAt=accountSession.ExpireAt.ToString(),
                Permissions=admin.Role.Permissions
            };


        }else if(admin is null){

            var teacher=_dbContext.Teachers.Where(x=>x.Status).FirstOrDefault(x=>x.Email==request.Email);
            if(teacher is not null){


            if (!PasswordHelper.VerifyPassword(request.Password,teacher!.Password))
            {
                return ValidationError(nameof(request.Password),"password is not correct or this admin is blocked");
            }
            AccountSession accountSession =await _jwtRepository.GetTokensInfo(teacher.Id, teacher.Email,nameof(JwtSchema.Teacher),null);
            accountSession.FcmToken=request.FcmToken;
            _dbContext.AccountSessions.Add(accountSession);
            _dbContext.SaveChanges();
            Response=new LoginAdminDto{
                Token=accountSession.Token,
                IsAdmin=false,
                Id=teacher.Id,
                RefreshToken=accountSession.RefreshToken,
                ExpireAt=accountSession.ExpireAt.ToString(),
            };


            }else{

                return ValidationError("Email","this email is not correct");
            }



        }        
        return Success(Response,"this this your login info");
        
    }
}