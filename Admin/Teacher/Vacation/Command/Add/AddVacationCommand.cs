using Common.CQRS;
using Shared.CQRS;

namespace Admin.Teacher.Vacation.Command.Add;

public class AddVacationCommand:ICommand
{
    public string Reason { get; set; }
    public int Days { get; set; }
    
}