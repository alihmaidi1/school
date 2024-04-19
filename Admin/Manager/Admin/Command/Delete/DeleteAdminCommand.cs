using Common.CQRS;
using Shared.CQRS;

namespace Admin.Manager.Admin.Command.Delete;

public class DeleteAdminCommand:ICommand
{
    public DeleteAdminCommand(Guid id)
    {
        this.Id = id;
    }
    
    
    public Guid Id { get; set; }
}