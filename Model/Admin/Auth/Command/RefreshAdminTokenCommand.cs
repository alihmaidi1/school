using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Model.Admin.Auth.Command;

public class RefreshAdminTokenCommand:IRequest<JsonResult>
{
    
    
    public string RefreshToken { get; set; }
    
}