using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Repository.Manager.Admin;
using Shared.OperationResult;

namespace Admin.Auth.Command.Logout;

public class LogoutAdminHandler:OperationResult,
    IRequestHandler<LogoutAdminCommand, JsonResult>
{
    private readonly IHttpContextAccessor _httpContextAccessor;
    private IAdminRepository AdminRepository;

    public LogoutAdminHandler(IHttpContextAccessor _httpContextAccessor,IAdminRepository adminRepository)
    {

        this._httpContextAccessor = _httpContextAccessor;
        this.AdminRepository = adminRepository;

    }
    
    public async Task<JsonResult> Handle(LogoutAdminCommand request, CancellationToken cancellationToken)
    {
    
        string Token = _httpContextAccessor.HttpContext.Request.Headers.Authorization.ToString().Split(" ")[1];
        bool status = AdminRepository.Logout(Token);
        return Success(status, "You Are Logout Successfully");

    }
}