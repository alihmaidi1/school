using Common.CQRS;
using Shared.CQRS;

namespace Admin.Teacher.Vacation.Command.ChangeStatus;

public  class ChnageVacationStatusCommand:ICommand
{
    
    public Guid Id { get; set; }
    
    public bool Status { get; set; }
}