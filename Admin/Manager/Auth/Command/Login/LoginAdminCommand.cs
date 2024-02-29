using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Admin.Auth.Command.Login;

public class LoginAdminCommand:IRequest<JsonResult>
{
 
    
    public string Email { get; set; }

    public string Password { get; set; }

}