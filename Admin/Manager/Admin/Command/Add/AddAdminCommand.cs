using Common.CQRS;
using Shared.CQRS;

namespace Admin.Admin.Command.AddAdmin;

public class AddAdminCommand:ICommand
{
    public string Name { get; set; }

    public string Email { get; set; }
    public string Password { get; set; }

    public Guid RoleId { get; set; }
    
    public string Image { get; set; }
}