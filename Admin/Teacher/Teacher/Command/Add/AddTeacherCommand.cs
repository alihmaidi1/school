using Common.CQRS;
using Shared.CQRS;

namespace Admin.Teacher.Teacher.Command.Add;

public class AddTeacherCommand:ICommand
{
    
    public string Name { get; set; }
    
    public string Email { get; set; }

    public string Password { get; set; }
    

    public Guid Image { get; set; }

    public Guid SubjectId{get;set;}
    
    
}