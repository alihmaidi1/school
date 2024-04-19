using Common.CQRS;
using Shared.CQRS;

namespace Admin.Student.Parent.Command.Add;

public class AddParentCommand:ICommand
{
    
    public string Name { get; set; }
    
    public string Email { get; set; }
    
    public string Password { get; set; }
    
    public string? Url { get; set; }

    

    
}