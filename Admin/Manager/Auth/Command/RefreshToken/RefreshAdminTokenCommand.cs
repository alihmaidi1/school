using Shared.CQRS;

namespace Admin.Manager.Auth.Command.RefreshToken;

public class RefreshAdminTokenCommand: ICommand
{
    public string RefreshToken { get; init; }
    
}