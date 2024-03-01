using Common.CQRS;

namespace Admin.Teacher.Teacher.Command.Add;

public class AddTeacherCommand:ICommand
{
    
    public string Name { get; set; }
    
    public string Email { get; set; }

    public string Password { get; set; }
    
    public bool Status { get; set; }

    public string? Image { get; set; }
    
    
}