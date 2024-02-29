using Common.CQRS;

namespace Admin.Manager.Role.Command.Delete;

public class DeleteRoleCommand:ICommand
{

    public Guid Id { get; set; }
    
}