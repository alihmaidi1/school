using Common.CQRS;

namespace Admin.Manager.Admin.Command.Update;

public class UpdateAdminCommand : ICommand
{
    public Guid AdminId { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public Guid RoleId { get; set; }
    public string? Image { get; set; }
    public bool Status { get; set; }
    
}