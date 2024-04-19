using Common.CQRS;
using Shared.CQRS;

namespace Admin.Teacher.Warning.Command.Add;

public class AddWarningCommand:ICommand
{
    public string Reson { get; set; }
    
    public Guid TeacherID { get; set; }

    
}