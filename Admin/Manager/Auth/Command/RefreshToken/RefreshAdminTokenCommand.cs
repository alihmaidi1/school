using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Admin.Auth.Command.RefreshToken;

public class RefreshAdminTokenCommand:IRequest<JsonResult>
{
    
    public string RefreshToken { get; set; }
    
}