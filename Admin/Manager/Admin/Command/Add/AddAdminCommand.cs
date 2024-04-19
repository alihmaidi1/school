using Shared.CQRS;

namespace Admin.Manager.Admin.Command.Add;

public class AddAdminCommand:ICommand
{
    public string Name { get; set; }

    public string Email { get; set; }
    
    
    public string Password { get; set; }

    public Guid RoleId { get; set; }
    
    public Guid ImageId { get; set; }
}