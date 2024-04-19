using Common.CQRS;
using Shared.CQRS;

namespace Admin.Manager.Role.Command.Update;

public class UpdateRoleCommand:ICommand
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public List<string> Permissions { get; set; }
}