using Common.CQRS;
using Shared.CQRS;

namespace Admin.Teacher.Teacher.Command.Update;

public class UpdateTeacherCommand:ICommand
{
    
    public Guid Id { get; set; }
  
    public string Name { get; set; }
    
    public string Email { get; set; }


    public string Password { get; set; }
    
    public bool Status { get; set; }

    public Guid? Image { get; set; }
    
}