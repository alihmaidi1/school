using Admin.Manager.Auth.Command.Login;
using Admin.Manager.Auth.Command.Logout;
using Admin.Manager.Auth.Command.RefreshToken;
using Dto.Admin.Auth.Dto;
using infrastructure;
using infrastructure.Attribute;
using Microsoft.AspNetCore.Mvc;
using schoolManagement.Base;
using Shared.Enum;
using Shared.OperationResult.Base;
using Shared.Swagger;

namespace schoolmanagment.Controllers.Admin;


[ApiGroup(ApiGroupName.All, ApiGroupName.Admin)]

[Route("Api/SuperAdmin/[controller]/[action]")]

public class AuthController:ApiController
{
    private ApplicationDbContext _context;

    public AuthController(ApplicationDbContext _context)
    {
        this._context = _context;

    }
    
    
    
    /// <summary>
    /// Login admin to dashboard
    /// </summary>
    [HttpPost]
    [Produces(typeof(OperationResultBase<AdminRefreshTokenDto>))]

    public async Task<IActionResult> Login([FromBody] LoginAdminCommand command,CancellationToken Token)
    {
        var response = await this.Mediator.Send(command,Token);
        return response;

    }
    
    
    
    /// <summary>
    /// logout admin from dashboard
    /// </summary>
    [CheckTokenSession(AuthenticationSchemes =nameof(JwtSchema.Admin))]
    [HttpPost]
    [Produces(typeof(OperationResultBase<Boolean>))]

    public async Task<IActionResult> Logout()
    {
        var response = await this.Mediator.Send(new LogoutAdminCommand());
        return response;
    }

    
    /// <summary>
    /// Refresh Admin token and refresh token  for use at one time
    /// </summary>
    [HttpPost]
    [Produces(typeof(OperationResultBase<AdminRefreshTokenDto>))]

    public async Task<IActionResult> RefreshToken([FromBody] RefreshAdminTokenCommand command)
    {
        var response =await this.Mediator.Send(command);
        return response;
    }



    
    
}