using Common.CQRS;
using Shared.CQRS;

namespace Admin.Manager.Role.Command.Delete;

public class DeleteRoleCommand:ICommand
{

    public Guid Id { get; set; }
    
}