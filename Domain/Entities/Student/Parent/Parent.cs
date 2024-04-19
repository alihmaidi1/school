using Common.Entity.Entity;
using EntityFrameworkCore.EncryptColumn.Attribute;
using Shared.Entity.Entity;

namespace Domain.Entities.Student.Parent;

public class Parent:BaseEntity
{

    public Parent()
    {

        Id = Guid.NewGuid();
        Students = new HashSet<Student.Student>();
    }
    public string Name { get; set; }
    
    public string Email { get; set; }
    
    public string Password { get; set; }
    
    public string? Image { get; set; }
    
    public string? Resize { get; set; }

    public string? Hash { get; set; }
    public ICollection<Student.Student> Students { get; set; }
}