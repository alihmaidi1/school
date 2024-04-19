using Common.CQRS;
using Shared.CQRS;

namespace Admin.Manager.Role.Command.Add;

public class AddRoleCommand:ICommand
{
    public string Name { get; set; }

    public List<string> Permissions { get; set; }
}