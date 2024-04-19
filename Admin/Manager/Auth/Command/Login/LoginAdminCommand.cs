using Common.CQRS;
using Shared.CQRS;

namespace Admin.Manager.Auth.Command.Login;

public class LoginAdminCommand: ICommand
{
 
    
    public string Email { get; init; }

    public string Password { get; init; }

}